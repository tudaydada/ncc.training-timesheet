using Microsoft.EntityFrameworkCore;
using TimeSheet.Model.Entity;
using TimeSheet.Services.Interface;

namespace TimeSheet.Services.Implement
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly DbSet<Client> clients;
        public ClientService(IClientRepository clientRepository, IProjectRepository projectRepository)
        {
            _clientRepository = clientRepository;
            _projectRepository = projectRepository;

            clients = _clientRepository.GetAll();
        }

        public ObjectResponse GetAllClient()
        {
            var result = from client in clients
                         select new
                         {
                             Id = client.Id,
                             Name = client.Name,
                         };
            return new ObjectResponse
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
        }

        public ObjectResponse GetClientHasProject()
        {
            var projects = _projectRepository.GetAll();
            var result = from c in clients
                         join p in projects on c.Id equals p.ClientId
                         select new
                         {
                             Id=c.Id,
                             ClientName = c.Name,
                             ProjectName = p.Name
                         };
            return new ObjectResponse
            {
                Code = 200,
                Message = "Success",
                Data = result
            };
        }

        public ObjectResponse GetClientHasProject(string clientCode)
        {
            var clients = _clientRepository.GetByCode(clientCode);
            var projects = _projectRepository.GetAll();
            var result = from c in clients
                         join p in projects on c.Id equals p.ClientId
                         select new
                         {
                             ClientName = c.Name,
                             ProjectName = p.Name
                         };

            if (result != null)
                return new ObjectResponse
                {
                    Code = 200,
                    Message = "Success",
                    Data = result
                };
            else
                return new ObjectResponse
                {
                    Code = 404,
                    Message = "Failed"
                };

        }
    }
}
