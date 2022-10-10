using TimeSheet.Request;

namespace TimeSheet.Services
{
    public interface IProjectService
    {
        public ObjectResponse GetAllProject(int status,string search);
        public ObjectResponse GetQuantityProject();
        public ObjectResponse GetById(int id);
        public ObjectResponse Create(ProjectRequest projectRequest);
        public ObjectResponse Update(int id,ProjectRequest projectRequest);
        public ObjectResponse Delete(int id);
        public ObjectResponse ChangeStatus(int id,int status);
        public bool IsValidProject(ProjectRequest projectRequest);
    }
}
