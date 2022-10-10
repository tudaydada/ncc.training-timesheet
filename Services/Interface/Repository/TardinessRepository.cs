using TimeSheet.Data;
using TimeSheet.Model.Entity;

namespace TimeSheet.Services.Interface.Repository
{
    public class TardinessRepository : BaseRepository<Tardiness>, ITardinessRepository
    {
        public TardinessRepository(TimeSheetDataContext context) : base(context)
        {
        }
    }
}
