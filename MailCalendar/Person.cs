namespace MailCalendar.Classes
{

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; }
        public string Email { get; }
        public Dictionary<int, bool> presence { get; private set; }

        public Person(string lastName, string email)
        {
            this.LastName = lastName;
            this.Email = email;
        }
    }
    
    
}