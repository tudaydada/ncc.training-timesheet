using TimeSheet.Data;
using TimeSheet.Model.Entity;

namespace TimeSheet.Services.Interface.Repository
{
    public class TaskTypeRepository : BaseRepository<TaskType>, ITaskTypeRepository
    {
        public TaskTypeRepository(TimeSheetDataContext context) : base(context)
        {
        }
    }
}
