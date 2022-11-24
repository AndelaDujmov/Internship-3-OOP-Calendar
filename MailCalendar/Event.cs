namespace MailCalendar.Classes
{

    public class Event
    {
        public int ID { get; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Person> Emails { get; private set; }

        public Event(int id)
        {
            this.ID = id;
        }

        public void SetEventEmails(List<Person> emails)
        {
            this.Emails = emails;

            for (int i = 0; i < this.Emails.Count; i++)
            {
                this.Emails[i].presence = new Dictionary<int, bool>();
                this.Emails[i].presence.Add(this.ID, true);
            }
        }
    
        public void PrintActiveEvents()
        {

            if (this.EndDate > DateTime.Now)
            {
                Console.WriteLine($"ID: {this.ID}\nEvent name: {this.Name}\nEvent location: {this.Location}\nEnds in: {this.EndDate}\n");
                Console.WriteLine("The list of guests:");
                this.Emails.ForEach(person => Console.WriteLine($"{person.Email}, "));
                Console.WriteLine("\n");
            }

        }

        public void NoteAbsents(int id, string email)
        {
            foreach (var var in this.Emails)
            {
                if (var.Email.Equals(email))
                {
                    var.presence.Clear();
                    var.presence.Add(id, false); 
                }
            }
        }

        public void UpcommingEvents()
        {
            if (this.StartDate > DateTime.Now)
            {
                Console.WriteLine($"ID: {this.ID}\nEvent name: {this.Name}\nEvent location: {this.Location}\nBegins in: {this.StartDate.Subtract(DateTime.Now).Days} days\n");
                Console.WriteLine("The list of guests:");
                this.Emails.ForEach(person => Console.WriteLine($"{person.Email}, "));
                Console.WriteLine("\n");
            }
                
        }

        public void FinishedEvents()
        {

            var timeSpan = Math.Round(this.EndDate.Subtract(this.StartDate).TotalHours, 1);
            
            if (this.EndDate < DateTime.Now)
            {
                Console.WriteLine($"ID: {this.ID}\nEvent name: {this.Name}\nEvent location: {this.Location}\nEnded: {DateTime.Now.Subtract(this.EndDate).Days} days ago\nLasted: {timeSpan} hours\n");
                Console.WriteLine("The list of guests:");
                this.Emails.ForEach(person => Console.WriteLine($"{person.Email}, "));
                Console.WriteLine("\n");   
            }
        }

      
    }
}