using TimeSheet.Data;
using TimeSheet.Model.Entity;

namespace TimeSheet.Services.Interface.Repository
{
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(TimeSheetDataContext context) : base(context)
        {
        }
    }
}
