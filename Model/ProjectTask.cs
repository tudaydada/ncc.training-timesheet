using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Model.Entity
{
    public class ProjectTask
    {
        public int ProjectId { get; set; }
        public int TaskId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }
        [ForeignKey(nameof(TaskId))]
        public virtual Task Task { get; set; }
    }
}
