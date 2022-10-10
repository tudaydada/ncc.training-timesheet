using TimeSheet.Model.Entity;

namespace TimeSheet.Services.Interface
{
    public interface IProjectMemberRepository : IBaseRepository<ProjectMember>
    {
        public IEnumerable<ProjectMember> GetByProjectId(int id);
    }
}
