using TimeSheet.Data;
using TimeSheet.Model.Entity;

namespace TimeSheet.Services.Interface.Repository
{
    public class TimeSheetLogTypeRepository : BaseRepository<TimeSheetLogType>, ITimeSheetLogTypeRepository
    {
        public TimeSheetLogTypeRepository(TimeSheetDataContext context) : base(context)
        {
        }
    }
}
