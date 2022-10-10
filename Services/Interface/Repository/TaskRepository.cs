using TimeSheet.Data;
using Task = TimeSheet.Model.Entity.Task;
namespace TimeSheet.Services.Interface.Repository
{
    public class TaskRepository : BaseRepository<Task>, ITaskRepository
    {
        public TaskRepository(TimeSheetDataContext context) : base(context)
        {
        }
    }
}
