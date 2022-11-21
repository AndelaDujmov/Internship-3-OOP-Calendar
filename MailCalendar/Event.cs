namespace MailCalendar;

public class Event
{
    public Guid ID { get; }
    public string Name;
    public string Location;
    public DateTime StartDate;
    public DateTime EndDate;
    public List<string> Emails;
}