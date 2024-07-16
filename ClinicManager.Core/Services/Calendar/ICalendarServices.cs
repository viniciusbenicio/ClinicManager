using ClinicManager.Core.DTOs;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

namespace ClinicManager.Core.Services.Calendar
{
    public interface ICalendarServices
    {
        Task<CalendarService> ConnectGoogleAgenda(string[] scopes);
        Task<Event> CreateQuickEventGoogleCalendar(string description);
        Task<Event> CreateGoogleCalendar(GoogleCalendarDTO request);
        Task<IList<Event>> GetEventsGoogleCalendar();
        Task<Event> GetEventGoogleCalendar(string eventId);
        Task<string> DeleteEventGoogleCalendar(string eventId);
        Task<Event> UpdateEventGoogleCalendar(string eventId);
    }
}
