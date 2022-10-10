using TimeSheet.Data;
using TimeSheet.Model.Entity;

namespace TimeSheet.Services.Interface.Repository
{
    public class TimeSheetLogRepository : BaseRepository<TimeSheetLog>, ITimeSheetLogRepository
    {
        public TimeSheetLogRepository(TimeSheetDataContext context) : base(context)
        {
        }
    }
}
