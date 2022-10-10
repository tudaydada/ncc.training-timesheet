using TimeSheet.Data;
using TimeSheet.Model.Entity;

namespace TimeSheet.Services.Interface.Repository
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(TimeSheetDataContext context) : base(context)
        {
            
        }

        public IEnumerable<Client> GetByCode(string code)
        {
            return Find(c=>c.Code.Equals(code));
        }
    }
}
