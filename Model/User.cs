using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Model.Entity
{
    public class User : WorkingTime
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public string EmailAddress { get; set; }
        public bool IsActive { get; set; }
        public int UserTypeId { get; set; }
        public int UserLevelId { get; set; }
        public int BranchId { get; set; }
        public DateTime StartDate { get; set; }
        public int AllowedLeaveDay { get; set; }
        public double Salary { get; set; }
        //public int? ManagerId { get; set; }

        [ForeignKey(nameof(UserTypeId))]
        public virtual UserType UserType { get; set; }
        [ForeignKey(nameof(UserLevelId))]
        public virtual UserLevel UserLevel { get; set; }
        [ForeignKey(nameof(BranchId))]
        public virtual Branch Branch { get; set; }
        //[NotMapped]
        //[ForeignKey(nameof(ManagerId))]
        //public virtual User Manager { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
        public virtual ICollection<Tardiness> Tardiness { get; set; }
        public virtual ICollection<TimeSheetLog> TimeSheetLogs { get; set; }
    }
}
