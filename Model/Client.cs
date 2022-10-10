namespace TimeSheet.Model.Entity
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
