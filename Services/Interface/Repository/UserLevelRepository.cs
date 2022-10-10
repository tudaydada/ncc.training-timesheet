using TimeSheet.Data;
using TimeSheet.Model.Entity;

namespace TimeSheet.Services.Interface.Repository
{
    public class UserLevelRepository : BaseRepository<UserLevel>, IUserLevelRepository
    {
        public UserLevelRepository(TimeSheetDataContext context) : base(context)
        {
        }
    }
}
