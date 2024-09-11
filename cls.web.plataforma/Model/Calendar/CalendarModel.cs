namespace cls.web.plataforma.Model.Calendar
{
    public class CalendarModel
    {
        public int id { get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public int total { get; set; }
        public int available { get; set; }
        public DateTime calendarDate { get; set; }
    }
}
