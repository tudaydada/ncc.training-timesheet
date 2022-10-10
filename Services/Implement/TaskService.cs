using Microsoft.EntityFrameworkCore;
using TimeSheet.Model.Entity;
using TimeSheet.Services.Interface;
using Task = TimeSheet.Model.Entity.Task;

namespace TimeSheet.Services.Implement
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;
        private readonly DbSet<Task> tasks;
        public TaskService(ITaskRepository taskRepository)
        {
                this.taskRepository = taskRepository;
            tasks = this.taskRepository.GetAll();
        }
        public ObjectResponse GetAll()
        {
            var result = tasks.Select(e => new
            {
                Id = e.Id,
                Name = e.Name,
                Typep = e.TaskTypeId,
                IsDeleted = e.IsDeleted,
            });
            return new ObjectResponse
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
        }
    }
}
