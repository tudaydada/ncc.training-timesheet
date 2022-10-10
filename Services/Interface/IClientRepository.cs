using System.Security.Principal;
using TimeSheet.Model.Entity;

namespace TimeSheet.Services.Interface
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        public IEnumerable<Client> GetByCode(string code);
    }
}
