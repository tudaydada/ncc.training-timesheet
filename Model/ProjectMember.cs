using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Model.Entity
{
    public class ProjectMember
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int UserStatusId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }
        [ForeignKey(nameof(UserStatusId))]
        public virtual UserStatus UserStatus { get; set; }

    }
}
