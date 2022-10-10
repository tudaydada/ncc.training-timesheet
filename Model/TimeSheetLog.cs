using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Model.Entity
{
    public class TimeSheetLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public int TaskId { get; set; }
        public string Note { get; set; }
        public double WorkingTime { get; set; }
        public int TimeSheetLogTypeId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }



        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public virtual Project Project { get; set; }
        [ForeignKey(nameof(TaskId))]
        public virtual Task Task { get; set; }
        [ForeignKey(nameof(TimeSheetLogTypeId))]
        public virtual TimeSheetLogType TimeSheetLogType { get; set; }
    }
}
