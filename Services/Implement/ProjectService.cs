using Microsoft.EntityFrameworkCore;
using System.Data;
using TimeSheet.Model.Entity;
using TimeSheet.Request;
using TimeSheet.Services.Interface;

namespace TimeSheet.Services.Implement
{

    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository;
        private readonly IClientRepository clientRepository;
        private readonly IUserRepository userRepository;
        private readonly IProjectMemberRepository projectMemberRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IProjectStatusRepository projectStatusRepository;
        private readonly ITaskRepository taskRepository;
        private readonly IProjectTypeRepository projectTypeRepository;
        private readonly IProjectTaskRepository projectTaskRepository;
        private readonly DbSet<Project> projects;
        private readonly DbSet<Client> clients;
        public ProjectService(IProjectRepository projectRepository
            , IClientRepository clientRepository
            , IUserRepository userRepository
            , IProjectMemberRepository projectMemberRepository
            , IRoleRepository roleRepository
            , IProjectStatusRepository projectStatusRepository
            , ITaskRepository taskRepository
            , IProjectTypeRepository projectTypeRepository
            , IProjectTaskRepository projectTaskRepository)
        {
            this.projectRepository = projectRepository;
            this.clientRepository = clientRepository;
            this.userRepository = userRepository;
            this.projectMemberRepository = projectMemberRepository;
            this.roleRepository = roleRepository;
            this.projectStatusRepository = projectStatusRepository;
            this.taskRepository = taskRepository;
            this.projectTypeRepository = projectTypeRepository;
            this.projectTaskRepository = projectTaskRepository;

            projects = this.projectRepository.GetAll();
            clients = this.clientRepository.GetAll();
        }

        public ObjectResponse ChangeStatus(int id, int status)
        {
            var projectStatuses = projectStatusRepository.GetAll().Select(e => e.Id);
            var isTrue = (from project in projects
                          where project.Id == id && projectStatuses.Any(e => e == status)
                          select 1).Count() > 0;
            if (isTrue)
                return new ObjectResponse
                {
                    Code = 400,
                    Message = "Invalid fields"
                };
            else
            {
                var project = projectRepository.GetById(id);
                if (project == null)
                    return new ObjectResponse
                    {
                        Code = 404,
                        Message = "Project is not found"
                    };
                else
                {
                    project.ProjectStatusId = status;
                    projectRepository.Update(project);
                    projectRepository.SaveChanges();
                    var result = GetById(id);
                    result.Message = "Changed";
                    return result;
                }
            }
        }

        public ObjectResponse Create(ProjectRequest projectRequest)
        {
            if (!IsValidProject(projectRequest))
            {
                return new ObjectResponse
                {
                    Code = 404,
                    Message = "Invalid fields"
                };
            }
            else
            {
                var project = new Project();
                project.ProjectTypeId = projectRequest.ProjectTypeId;
                project.ClientId = projectRequest.ClientId;
                project.ProjectStatusId = projectRequest.StatusId;
                project.Code = projectRequest.Code;
                project.Name = projectRequest.Name;
                project.Note = projectRequest.Note;
                project.StartAt = projectRequest.StartAt;
                project.EndAt = projectRequest.EndAt;
                projectRepository.Create(project);
                projectRepository.SaveChanges();
                project.Id = projects.Max(e => e.Id);
                var projectTask = new ProjectTask();
                foreach (var item in projectRequest.TasksId)
                {
                    projectTask.ProjectId = project.Id;
                    projectTask.TaskId = item;
                    projectTaskRepository.Create(projectTask);
                    projectTaskRepository.SaveChanges();
                }

                var projectMember = new ProjectMember();
                foreach (var item in projectRequest.TeamMembers)
                {
                    projectMember.ProjectId = project.Id;
                    projectMember.UserId = item.UserId;
                    projectMember.RoleId = item.RoleId;
                    projectMember.UserStatusId = new Random().Next(1, 3);
                    projectMemberRepository.Create(projectMember);
                    projectMemberRepository.SaveChanges();
                }

                return GetById(project.Id);

            }

        }

        public ObjectResponse Delete(int id)
        {

            var project = projectRepository.GetById(id);
            if (project == null)
                return new ObjectResponse
                {
                    Code = 404,
                    Message = "Project is not found"
                };
            else
            {
                //deleteTask
                var projectTaskIds = projectTaskRepository.GetAll().Where(e => e.ProjectId == id).Select(e => e.TaskId).ToList();
                projectTaskIds.ForEach(e =>
                {
                    projectTaskRepository.Delete(e);
                    projectRepository.SaveChanges();
                });
                //deleteProjectMember
                var projectMemberIds = projectMemberRepository.GetAll().Where(e => e.ProjectId == id).Select(e => new { e.ProjectId, e.UserId }).ToList();
                projectMemberIds.ForEach(e =>
                {
                    var projectMember = projectMemberRepository.Find(p => p.ProjectId == e.ProjectId && p.UserId == e.UserId).FirstOrDefault();
                    if (projectMember != null)
                    {
                        projectMemberRepository.Delete(projectMember);
                        projectMemberRepository.SaveChanges();
                    }
                });



                //deleteProject
                projectRepository.Delete(project);
                var projectTask = new ProjectTask();
                projectRepository.SaveChanges();
                return new ObjectResponse
                {
                    Code = 200,
                    Message = "Deleted"
                };
            }

        }

        public ObjectResponse GetAllProject(int status, string search)
        {
            var projectMembers = projectMemberRepository.GetAll();
            var users = userRepository.GetAll();
            var roles = roleRepository.GetAll();
            var result = from g in (from projectMember in projectMembers
                                    join role in roles on projectMember.RoleId equals role.Id
                                    join user in users on projectMember.UserId equals user.Id
                                    //where role.Normalized.ToLower().Equals("pm")
                                    group new
                                    {
                                        username = user.UserName,
                                        role = role.Normalized,
                                        memerStatusId = projectMember.UserStatusId
                                    } by projectMember.ProjectId into g
                                    select new
                                    {
                                        ProjectId = g.Key,
                                        Members = g.Where(e => e.role.ToLower().Equals("pm")).Select(e => e.username),
                                        Active = g.Count(e => e.memerStatusId == 1)
                                    })
                         join project in projects on g.ProjectId equals project.Id
                         join client in clients on project.ClientId equals client.Id
                         select new
                         {
                             Id = project.Id,
                             Code = project.Code,
                             Name = project.Name,
                             ClientName = client.Name,
                             Members = g.Members,
                             ActiveMembers = g.Active,
                             ProjectType = project.ProjectTypeId,
                             TimeStart = project.StartAt,
                             TimeEnd = project.EndAt
                         };
            return new ObjectResponse
            {
                Code = 200,
                Message = "Success",
                Data = result.ToList()
            };

        }

        public ObjectResponse GetById(int id)
        {
            var projectMembers = projectMemberRepository.GetAll();
            var users = userRepository.GetAll();
            var roles = roleRepository.GetAll();
            var result = from g in (from projectMember in projectMembers
                                    join role in roles on projectMember.RoleId equals role.Id
                                    join user in users on projectMember.UserId equals user.Id
                                    //where role.Normalized.ToLower().Equals("pm")
                                    group new
                                    {
                                        username = user.UserName,
                                        role = role.Normalized,
                                        memerStatusId = projectMember.UserStatusId
                                    } by projectMember.ProjectId into g
                                    select new
                                    {
                                        ProjectId = g.Key,
                                        Members = g.Where(e => e.role.ToLower().Equals("pm")).Select(e => e.username),
                                        Active = g.Count(e => e.memerStatusId == 1)
                                    })
                         join project in projects on g.ProjectId equals project.Id
                         join client in clients on project.ClientId equals client.Id
                         where project.Id == id
                         select new
                         {
                             Id = project.Id,
                             Code = project.Code,
                             Name = project.Name,
                             ClientName = client.Name,
                             Members = g.Members,
                             ActiveMembers = g.Active,
                             ProjectType = project.ProjectTypeId,
                             TimeStart = project.StartAt,
                             TimeEnd = project.EndAt
                         };
            if (result == null)
                return new ObjectResponse
                {
                    Code = 404,
                    Message = "Not found"
                };
            else
                return new ObjectResponse
                {
                    Code = 200,
                    Message = "Success",
                    Data = result
                };
        }

        public ObjectResponse GetQuantityProject()
        {
            var result = from project in projects
                         group project.Id by project.ProjectStatusId into g
                         select new
                         {
                             StatusId = g.Key,
                             Quantity = g.Count()
                         };
            return new ObjectResponse
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
        }

        public bool IsValidProject(ProjectRequest projectRequest)
        {
            var usersId = userRepository.GetAll().Select(e => e.Id).ToArray();
            var tasksId = taskRepository.GetAll().Select(e => e.Id).ToArray();
            var rolesId = roleRepository.GetAll().Select(e => e.Id).ToArray();
            var statusesId = projectStatusRepository.GetAll().Select(e => e.Id).ToArray();
            var typesId = projectTypeRepository.GetAll().Select(e => e.Id).ToArray();
            var clientsId = clients.Select(e => e.Id).ToArray();

            var result = projectRequest.TeamMembers.Select(e => e.UserId).ToArray().All(e => usersId.Contains(e)) &&
                        projectRequest.TasksId.All(e => tasksId.Contains(e)) &&
                        projectRequest.TeamMembers.Select(e => e.RoleId).ToArray().All(e => rolesId.Contains(e)) &&
                        statusesId.Contains(projectRequest.StatusId) &&
                        typesId.Contains(projectRequest.ProjectTypeId) &&
                        clientsId.Contains(projectRequest.ClientId);
            return result;
        }

        public ObjectResponse Update(int id, ProjectRequest projectRequest)
        {
            if (!IsValidProject(projectRequest))
            {
                return new ObjectResponse
                {
                    Code = 404,
                    Message = "Invalid fields"
                };
            }
            else
            {
                var project = projectRepository.GetById(id);
                project.ProjectTypeId = projectRequest.ProjectTypeId;
                project.ClientId = projectRequest.ClientId;
                project.ProjectStatusId = projectRequest.StatusId;
                project.Code = projectRequest.Code;
                project.Name = projectRequest.Name;
                project.Note = projectRequest.Note;
                project.StartAt = projectRequest.StartAt;
                project.EndAt = projectRequest.EndAt;
                projectRepository.Update(project);
                projectRepository.SaveChanges();


                //Task
                var projectTasksId = projectTaskRepository.GetAll().Where(e => e.ProjectId == id).Select(e => e.TaskId).ToArray();
                var projectTasksIdRequest = projectRequest.TasksId.ToArray();
                var projectTasksIdDelete = projectTasksId.Except(projectTasksIdRequest);

                foreach (var item in projectTasksIdDelete)
                {
                    var projectTaskDelete = projectTaskRepository.Find(e => e.ProjectId == id && e.TaskId == item).FirstOrDefault();
                    //delete
                    if (projectTaskDelete != null)
                    {
                        projectTaskRepository.Delete(projectTaskDelete);
                        projectTaskRepository.SaveChanges();
                    }
                }
                var projectTask = new ProjectTask();
                projectTask.ProjectId = id;
                foreach (var item in projectTasksIdRequest)
                {
                    if (!projectTasksId.Contains(item))
                    {
                        //Create
                        projectTask.TaskId = item;
                        projectTaskRepository.Create(projectTask);
                        projectTaskRepository.SaveChanges();
                    }

                }

                var projectMembersRequest = projectRequest.TeamMembers;
                var usersIdRequest = projectMembersRequest.Select(e => e.UserId).ToArray();
                var projectMembers = projectMemberRepository.GetAll()
                    .Where(e => e.ProjectId == id)
                    .Select(e => new { e.ProjectId, e.UserId });
                var projectMember = new ProjectMember();

                foreach (var item in projectRequest.TeamMembers)
                {
                    projectMember.UserId = item.UserId;
                    projectMember.RoleId = item.RoleId;
                    projectMember.UserStatusId = new Random().Next(1, 3);

                    if (projectMembers.Any(e => e.UserId == item.UserId))
                    {
                        //update
                        projectMember.ProjectId = id;
                        projectMemberRepository.Update(projectMember);
                        projectMemberRepository.SaveChanges();
                    }
                    else
                    {
                        //create
                        projectMemberRepository.Create(projectMember);
                        projectMemberRepository.SaveChanges();
                    }

                }
                var projectMemberDelete = projectMembers.Select(e => e.UserId).ToArray().Except(usersIdRequest).ToList();
                projectMemberDelete.ForEach(e =>
                {
                    var delete = projectMemberRepository.Find(p => p.ProjectId == id && p.UserId == e).FirstOrDefault();
                    //delete
                    if (delete != null)
                    {
                        projectMemberRepository.Delete(delete);
                        projectMemberRepository.SaveChanges();

                    }
                });
                return GetById(project.Id);

            }
        }
    }
}
