using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Model.Entity
{
    public class Tardiness
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public double RegistrationStart { get; set; }
        public double RegistrationEnd { get; set; }
        public double CheckIn { get; set; }
        public double CheckOut { get; set; }
        public int TardinessStatusId { get; set; }
        public int? EditorId { get; set; }
        public string UserNote { get; set; }
        public string NoteReply { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        [ForeignKey(nameof(TardinessStatusId))]
        public virtual TardinessStatus TardinessStatus { get; set; }
        [NotMapped]
        [ForeignKey(nameof(EditorId))]
        public virtual User Editor { get; set; }
    }
}
