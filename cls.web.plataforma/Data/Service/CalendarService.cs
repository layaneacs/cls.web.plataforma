using System.Text.Json;
using cls.web.plataforma.Data.Interface;
using cls.web.plataforma.Model.Calendar;

namespace cls.web.plataforma.Data.Service
{
    public class CalendarService : ICalendarService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ISessionContext _sessionContext;

        public CalendarService(IHttpClientFactory httpClient, ISessionContext sessionContext)
        {
            _httpClient = httpClient;
            _sessionContext = sessionContext;
        }

        public async Task<CalendarModel[]> Get()
        {
            try
            {
                var client = _httpClient.CreateClient();
                var endpoint = $"calendar/calendars?DayIn=2024-02-14&DayOut=2024-12-31";
                client.BaseAddress = new Uri("http://localhost:5218");
                var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, endpoint);

                var httpResponseMessage = await client.SendAsync(httpRequestMessage);

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var responseValue = await httpResponseMessage.Content.ReadAsStreamAsync();
                    var response = await JsonSerializer.DeserializeAsync<CalendarModel[]>(responseValue);
                    return response ?? default;
                }

                return default;
            }
            catch (Exception err)
            {
                //throw new Exception("PersonService", err);
                return default;
            }
        }
    }
}
