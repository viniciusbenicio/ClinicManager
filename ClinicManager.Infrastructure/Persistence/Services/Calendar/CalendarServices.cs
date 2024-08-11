using ClinicManager.Core.DTOs;
using ClinicManager.Core.Services.Calendar;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace ClinicManager.Infrastructure.Persistence.Services.Calendar
{
    public class CalendarServices : ICalendarServices
    {
        const string CALENDAR_ID = "primary";

        public CalendarServices()
        {

        }

        public async Task<CalendarService> ConnectGoogleAgenda(string[] scopes)
        {
            string applicationName = "Calendar Clinic Manager";
            UserCredential credential;
            string credPath = "token.json";

            var clientSecrets = new ClientSecrets
            {
                ClientId = ClinicManager.Core.Entities.Configuration.Calendar.Web.ClientId,
                ClientSecret = ClinicManager.Core.Entities.Configuration.Calendar.Web.ClientSecret,
            };

            credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(clientSecrets, scopes, "user", CancellationToken.None, new FileDataStore(credPath, true));

            var services = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName
            });

            return services;
        }

        public async Task<Event> CreateQuickEventGoogleCalendar(string description)
        {
            string[] scopes = { $"https://www.googleapis.com/calendar/v3/calendars/{CALENDAR_ID}/events/quickAdd" };
            var services = await ConnectGoogleAgenda(scopes);

            var requestCreate = services.Events.QuickAdd(CALENDAR_ID, description).Execute();

            return requestCreate;
        }

        public async Task<Event> CreateGoogleCalendar(GoogleCalendarDTO request)
        {
            string[] scopes = { "https://www.googleapis.com/auth/calendar " };
            var services = await ConnectGoogleAgenda(scopes);

            Event eventCalendar = new Event()
            {
                Summary = request.Summary,
                Location = request.Location,
                Start = new EventDateTime
                {
                    DateTime = request.Start,
                    TimeZone = "America/Sao_Paulo"
                },
                End = new EventDateTime
                {
                    DateTime = request.End,
                    TimeZone = "America/Sao_Paulo"
                },
                Description = request.Description,

            };

            var eventRequest = services.Events.Insert(eventCalendar, CALENDAR_ID);
            var requestCreate = await eventRequest.ExecuteAsync();

            return requestCreate;
        }

        public async Task<IList<Event>> GetEventsGoogleCalendar()
        {
            string[] scopes = { $"https://www.googleapis.com/calendar/v3/calendars/{CALENDAR_ID}/events" };
            var services = await ConnectGoogleAgenda(scopes);

            var events = services.Events.List(CALENDAR_ID).Execute();

            return events.Items;
        }

        public async Task<Event> GetEventGoogleCalendar(string eventId)
        {
            string[] scopes = { $"https://www.googleapis.com/calendar/v3/calendars/{CALENDAR_ID}/events" };
            var services = await ConnectGoogleAgenda(scopes);

            var events = await services.Events.Get(CALENDAR_ID, eventId).ExecuteAsync();

            return events;
        }

        public async Task<string> DeleteEventGoogleCalendar(string eventId)
        {
            string[] scopes = { $"https://www.googleapis.com/calendar/v3/calendars/{CALENDAR_ID}/events/{eventId}" };
            var services = await ConnectGoogleAgenda(scopes);

            var events = await services.Events.Delete(CALENDAR_ID, eventId).ExecuteAsync();

            return events;
        }

        public async Task<Event> UpdateEventGoogleCalendar(string eventId)
        {
            string[] scopes = { $"https://www.googleapis.com/calendar/v3/calendars/{CALENDAR_ID}/events/{eventId}" };
            var services = await ConnectGoogleAgenda(scopes);

            Event eventCalendar = new Event()
            {
                Summary = "Atualizando",
                Location = "São Paulo",
                Start = new EventDateTime
                {
                    DateTime = DateTime.Parse("2023-03-25T00:49:18.227Z"),
                    TimeZone = "America/Sao_Paulo"
                },
                End = new EventDateTime
                {
                    DateTime = DateTime.Parse("2023-03-25T00:49:18.227Z"),
                    TimeZone = "America/Sao_Paulo"
                },
                Description = "Descrição do evento atualizado",

            };

            var events = await services.Events.Update(eventCalendar, CALENDAR_ID, eventId).ExecuteAsync();

            return events;
        }
    }
}