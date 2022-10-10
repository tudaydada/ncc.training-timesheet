using TimeSheet.Data;
using TimeSheet.Model.Entity;

namespace TimeSheet.Services.Interface.Repository
{
    public class TardinessStatusRepository : BaseRepository<TardinessStatus>, ITardinessStatusRepository
    {
        public TardinessStatusRepository(TimeSheetDataContext context) : base(context)
        {
        }
    }
}
