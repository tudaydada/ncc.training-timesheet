using TimeSheet.Request;

namespace TimeSheet.Services
{
    public interface ITimeSheetLogService
    {
        public ObjectResponse GetById(int id);
        public ObjectResponse GetByUserId(int id);
        public ObjectResponse Create(TimeSheetLogRequest timeSheetLogRequest);
        public ObjectResponse Update(int id, TimeSheetLogRequest timeSheetLogRequest);
        public ObjectResponse Delete(int id);
        public bool IsValidTimeSheetLog(TimeSheetLogRequest timeSheetLogRequest);
    }
}
