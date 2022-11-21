namespace MailCalendar;

public class Person
{
    public string FirstName;
    public string LastName { get; }
    public string Email { get; }
    public Dictionary<Guid,bool> presence;
}