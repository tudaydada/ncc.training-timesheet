using Microsoft.EntityFrameworkCore;
using TimeSheet.Model.Entity;
using TimeSheet.Request;
using TimeSheet.Services.Interface;
using Task = TimeSheet.Model.Entity.Task;

namespace TimeSheet.Services.Implement
{
    public class TimeSheetLogService : ITimeSheetLogService
    {
        private readonly ITimeSheetLogRepository timeSheetLogRepository;
        private readonly IProjectRepository projectRepository;
        private readonly ITaskRepository taskRepository;
        private readonly ITimeSheetLogTypeRepository timeSheetLogTypeRepository;
        private readonly IUserRepository userRepository;
        private readonly IClientRepository clientRepository;
        private readonly IProjectTaskRepository projectTaskRepository;
        private readonly IProjectMemberRepository projectMemberRepository;


        private readonly DbSet<TimeSheetLog> TimeSheetLogs;
        private readonly DbSet<Project> Projects;
        private readonly DbSet<Task> Tasks;
        private readonly DbSet<User> Users;
        private readonly DbSet<Client> Clients;
        public TimeSheetLogService(ITimeSheetLogRepository timeSheetLogRepository
                                , IProjectRepository projectRepository
                                , ITaskRepository taskRepository
                                , ITimeSheetLogTypeRepository timeSheetLogTypeRepository
                                , IUserRepository userRepository
                                , IClientRepository clientRepository
                                , IProjectTaskRepository projectTaskRepository
                                , IProjectMemberRepository projectMemberRepository)
        {
            this.projectRepository = projectRepository;
            this.timeSheetLogRepository = timeSheetLogRepository;
            this.taskRepository = taskRepository;
            this.userRepository = userRepository;
            this.clientRepository = clientRepository;
            this.projectTaskRepository = projectTaskRepository;
            this.projectMemberRepository = projectMemberRepository;
            this.timeSheetLogTypeRepository = timeSheetLogTypeRepository;


            TimeSheetLogs = timeSheetLogRepository.GetAll();
            Projects = projectRepository.GetAll();
            Tasks = taskRepository.GetAll();
            Users = userRepository.GetAll();
            Clients = clientRepository.GetAll();
        }

        public ObjectResponse Create(TimeSheetLogRequest timeSheetLogRequest)
        {
            
            if (!IsValidTimeSheetLog(timeSheetLogRequest))
                return new ObjectResponse
                {
                    Code = 400,
                    Message = "Invalid Fields"
                };
            else
            {
                TimeSheetLog timeSheetLog = new ();
                timeSheetLog.CreateAt = DateTime.Now;
                timeSheetLog.Note = timeSheetLogRequest.Note;
                timeSheetLog.UserId = timeSheetLogRequest.ProjectTargetUserId;
                timeSheetLog.ProjectId = timeSheetLogRequest.ProjectId;
                timeSheetLog.TaskId = timeSheetLogRequest.TaskId;
                timeSheetLog.TimeSheetLogTypeId = timeSheetLogRequest.TypeOfWorkId > 1 ? 2 : 1;
                timeSheetLog.WorkingTime = timeSheetLogRequest.WorkdingTime;
                timeSheetLogRepository.Create(timeSheetLog);
                timeSheetLogRepository.SaveChanges();
                var result = from t in TimeSheetLogs
                             join u in Users on t.UserId equals u.Id
                             join task in Tasks on t.TaskId equals task.Id
                             join p in Projects on t.ProjectId equals p.Id
                             join c in Clients on p.ClientId equals c.Id
                             where p.Id == timeSheetLog.ProjectId && task.Id == timeSheetLog.TaskId && u.Id == timeSheetLog.UserId
                             select new
                             {
                                 Id = t.Id,
                                 ProjectName = p.Name,
                                 TaskName = task.Name,
                                 ProjectTaskId = 0,
                                 CustomerName = c.Name,
                                 ProjectCode = p.Code,
                                 DateAt = t.CreateAt,
                                 WorkingTime = t.WorkingTime,
                                 Note = t.Note,
                                 TypeOfWork = t.TimeSheetLogTypeId
                             };
                return new ObjectResponse
                {
                    Code = 200,
                    Message = "Success",
                    Data = result.OrderByDescending(e => e.DateAt).FirstOrDefault()
                };
            }
        }

        public ObjectResponse Delete(int id)
        {
            var timeSheetLog = TimeSheetLogs.FirstOrDefault(t => t.Id == id);
            if (timeSheetLog == null)
                return new ObjectResponse { Code = 404, Message = "Not found" };
            else
            {
                timeSheetLogRepository.Delete(timeSheetLog);
                timeSheetLogRepository.SaveChanges();
                return new ObjectResponse { Code = 200, Message = "Success" };

            }
        }

        public ObjectResponse GetById(int id)
        {
            var resutlt = from t in TimeSheetLogs
                          join u in Users on t.UserId equals u.Id
                          join task in Tasks on t.TaskId equals task.Id
                          join p in Projects on t.ProjectId equals p.Id
                          join c in Clients on p.ClientId equals c.Id
                          where t.Id == id
                          select new
                          {
                              Id = t.Id,
                              ProjectName = p.Name,
                              TaskName = task.Name,
                              ProjectTaskId = 0,
                              CustomerName = c.Name,
                              ProjectCode = p.Code,
                              DateAt = t.CreateAt,
                              WorkingTime = t.WorkingTime,
                              Note = t.Note,
                              TypeOfWork = t.TimeSheetLogTypeId
                          };
            if (resutlt == null)
                return new ObjectResponse
                {
                    Code = 404,
                    Message = "Failed"
                };
            else
                return new ObjectResponse
                {
                    Code = 200,
                    Message = "Success",
                    Data = resutlt
                };
        }

        public ObjectResponse GetByUserId(int id)
        {
            var resutlt = from t in TimeSheetLogs
                          join u in Users on t.UserId equals u.Id
                          join task in Tasks on t.TaskId equals task.Id
                          join p in Projects on t.ProjectId equals p.Id
                          join c in Clients on p.ClientId equals c.Id
                          where t.UserId == id
                          select new
                          {
                              Id = t.Id,
                              ProjectName = p.Name,
                              TaskName = task.Name,
                              ProjectTaskId = 0,
                              CustomerName = c.Name,
                              ProjectCode = p.Code,
                              DateAt = t.CreateAt,
                              WorkingTime = t.WorkingTime,
                              Note = t.Note,
                              TypeOfWork = t.TimeSheetLogTypeId
                          };
            if (resutlt == null)
                return new ObjectResponse
                {
                    Code = 404,
                    Message = "Failed"
                };
            else
                return new ObjectResponse
                {
                    Code = 200,
                    Message = "Success",
                    Data = resutlt
                };
        }

        public bool IsValidTimeSheetLog(TimeSheetLogRequest timeSheetLogRequest)
        {
            var projectTasks = projectTaskRepository.GetAll();
            var projectMembers = projectMemberRepository.GetAll();
            var timeSheetLogTypes = timeSheetLogTypeRepository.GetAll();
            var isTrue = (from pm in projectMembers
                          join pt in projectTasks on pm.ProjectId equals pt.ProjectId
                          where pm.ProjectId == timeSheetLogRequest.ProjectId
                          && timeSheetLogRequest.ProjectTargetUserId == pm.UserId
                          && timeSheetLogRequest.TaskId == pt.TaskId
                          select pm.ProjectId).FirstOrDefault()>0;
            return (isTrue || (0 < timeSheetLogRequest.WorkdingTime || timeSheetLogRequest.WorkdingTime <= 8));
        }

        public ObjectResponse Update(int id,TimeSheetLogRequest timeSheetLogRequest)
        {
            if (!IsValidTimeSheetLog(timeSheetLogRequest))
                return new ObjectResponse
                {
                    Code = 400,
                    Message = "Invalid Fields"
                };
            else
            {
                TimeSheetLog timeSheetLog = timeSheetLogRepository.GetById(id);
                timeSheetLog.UpdateAt = DateTime.Now;
                timeSheetLog.Note = timeSheetLogRequest.Note;
                timeSheetLog.UserId = timeSheetLogRequest.ProjectTargetUserId;
                timeSheetLog.ProjectId = timeSheetLogRequest.ProjectId;
                timeSheetLog.TaskId = timeSheetLogRequest.TaskId;
                timeSheetLog.TimeSheetLogTypeId = timeSheetLogRequest.TypeOfWorkId > 1 ? 2 : 1;
                timeSheetLog.WorkingTime = timeSheetLogRequest.WorkdingTime;
                timeSheetLogRepository.Update(timeSheetLog);
                timeSheetLogRepository.SaveChanges();
                var resutlt = from t in TimeSheetLogs
                              join u in Users on t.UserId equals u.Id
                              join task in Tasks on t.TaskId equals task.Id
                              join p in Projects on t.ProjectId equals p.Id
                              join c in Clients on p.ClientId equals c.Id
                              where t.Id == timeSheetLog.Id
                              select new
                              {
                                  Id = t.Id,
                                  ProjectName = p.Name,
                                  TaskName = task.Name,
                                  ProjectTaskId = 0,
                                  CustomerName = c.Name,
                                  ProjectCode = p.Code,
                                  DateAt = t.CreateAt,
                                  WorkingTime = t.WorkingTime,
                                  Note = t.Note,
                                  TypeOfWork = t.TimeSheetLogTypeId
                              };
                if (resutlt == null)
                    return new ObjectResponse
                    {
                        Code = 404,
                        Message = "Failed"
                    };
                else
                    return new ObjectResponse
                    {
                        Code = 200,
                        Message = "Success",
                        Data = resutlt
                    };
            }
        }
    }
}
