namespace TimeSheet.Services
{
    public interface ITardinessService
    {
        public ObjectResponse CheckIn(int userId);
        public ObjectResponse CheckOut(int userId);
    }
}
