using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Model.Entity
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public int ClientId { get; set; }
        public string Note { get; set; }
        public int ProjectTypeId { get; set; }
        public int ProjectStatusId { get; set; }



        [ForeignKey(nameof(ClientId))]
        public virtual Client Client { get; set; }
        [ForeignKey(nameof(ProjectTypeId))]
        public virtual ProjectType ProjectType { get; set; }
        [ForeignKey(nameof(ProjectStatusId))]
        public virtual ProjectStatus ProjectStatus { get; set; }
        public virtual ICollection<ProjectTask> ProjectTasks { get; set; }
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
    }
}
