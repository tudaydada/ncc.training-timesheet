using TimeSheet.Data;
using TimeSheet.Model.Entity;

namespace TimeSheet.Services.Interface.Repository
{
    public class UserStatusRepository : BaseRepository<UserStatus>, IUserStatusRepository
    {
        public UserStatusRepository(TimeSheetDataContext context) : base(context)
        {
        }
    }
}
