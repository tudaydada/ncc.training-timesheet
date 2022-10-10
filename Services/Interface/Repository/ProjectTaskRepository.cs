using TimeSheet.Data;
using TimeSheet.Model.Entity;

namespace TimeSheet.Services.Interface.Repository
{
    public class ProjectTaskRepository : BaseRepository<ProjectTask>, IProjectTaskRepository
    {
        public ProjectTaskRepository(TimeSheetDataContext context) : base(context)
        {
        }

        public IEnumerable<ProjectTask> GetByProjectId(int id)
        {
            return Find(e => e.ProjectId == id);
        }
    }
}
