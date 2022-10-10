using TimeSheet.Data;
using TimeSheet.Model.Entity;

namespace TimeSheet.Services.Interface.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TimeSheetDataContext context) : base(context)
        {
        }
    }
}
