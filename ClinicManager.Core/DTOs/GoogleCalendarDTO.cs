namespace ClinicManager.Core.DTOs
{
    public class GoogleCalendarDTO
    {
        public string Summary { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public class GoogleQuickCalendarDTO
    {
        public string PrimaryId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
