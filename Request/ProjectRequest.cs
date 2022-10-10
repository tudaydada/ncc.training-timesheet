namespace TimeSheet.Request
{
    public class ProjectRequest
    {
        public string Name { get; set; }
        public string Code{ get; set; }
        public string Note { get; set; }
        public int ClientId { get; set; }
        public int ProjectTypeId { get; set; }
        public UserRoleRequest[] TeamMembers { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int[] TasksId { get; set; }
        public int StatusId { get; set; }
    }
}
