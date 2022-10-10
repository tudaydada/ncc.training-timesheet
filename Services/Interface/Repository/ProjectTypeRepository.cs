using TimeSheet.Data;
using TimeSheet.Model.Entity;

namespace TimeSheet.Services.Interface.Repository
{
    public class ProjectTypeRepository : BaseRepository<ProjectType>, IProjectTypeRepository
    {
        public ProjectTypeRepository(TimeSheetDataContext context) : base(context)
        {
        }
    }
}
