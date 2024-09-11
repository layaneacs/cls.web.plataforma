using cls.web.plataforma.Model.Calendar;

namespace cls.web.plataforma.Data.Interface
{
    public interface ICalendarService
    {
        Task<CalendarModel[]> Get();
    }
}
