namespace TimeSheet.Request
{
    public class TimeSheetLogRequest
    {
        public int ProjectId { get; set; }
        public int TaskId { get; set; }
        public string Note { get; set; }
        public double WorkdingTime { get; set; }
        public int TypeOfWorkId { get; set; }
        public int ProjectTargetUserId { get; set; }
    }
}