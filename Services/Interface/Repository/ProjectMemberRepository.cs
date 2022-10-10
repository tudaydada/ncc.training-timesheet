using TimeSheet.Data;
using TimeSheet.Model.Entity;

namespace TimeSheet.Services.Interface.Repository
{
    public class ProjectMemberRepository : BaseRepository<ProjectMember>, IProjectMemberRepository
    {
        public ProjectMemberRepository(TimeSheetDataContext context) : base(context)
        {
        }

        public IEnumerable<ProjectMember> GetByProjectId(int id)
        {
            return Find(e => e.ProjectId == id);
        }
    }
}
