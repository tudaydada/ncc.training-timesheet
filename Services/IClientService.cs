namespace TimeSheet.Services
{
    public interface IClientService
    {
        public ObjectResponse GetAllClient();
        public ObjectResponse GetClientHasProject();
        public ObjectResponse GetClientHasProject(string clientCode);
    }
}
