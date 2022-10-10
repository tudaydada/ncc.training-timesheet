namespace TimeSheet.Model.Entity
{
    public class Branch : WorkingTime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string DisplayName { get; set; }
        public string Color { get; set; }


        public virtual ICollection<User> Users { get; set; }
    }
}
