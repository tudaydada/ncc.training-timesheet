using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Model.Entity
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TaskTypeId { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey(nameof(TaskTypeId))]
        public virtual TaskType TaskType { get; set; }
    }
}
