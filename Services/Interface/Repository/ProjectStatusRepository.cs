using TimeSheet.Data;
using TimeSheet.Model.Entity;

namespace TimeSheet.Services.Interface.Repository
{
    public class ProjectStatusRepository : BaseRepository<ProjectStatus>, IProjectStatusRepository
    {
        public ProjectStatusRepository(TimeSheetDataContext context) : base(context)
        {
        }
    }
}
