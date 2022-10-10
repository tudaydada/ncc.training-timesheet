using TimeSheet.Model.Entity;

namespace TimeSheet.Services.Interface
{
    public interface IProjectTaskRepository : IBaseRepository<ProjectTask>
    {
        public IEnumerable<ProjectTask> GetByProjectId(int id);
    }
}
