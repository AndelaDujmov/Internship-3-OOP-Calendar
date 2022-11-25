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

        public Event(string name, string location, DateTime start, DateTime end)
        {
            this.Name = name;
            this.Location = location;
            this.StartDate = start;
            this.EndDate = end;
        }

        
        /*
        private Event(string name, string location, DateTime start, DateTime end, List<Person> persons)
        {
            this.Name = name;
            this.Location = location;
            this.StartDate = start;
            this.EndDate = end;
            this.Emails = persons;
        }
        */
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
                Console.WriteLine(
                    $"ID: {this.ID}\nEvent name: {this.Name}\nEvent location: {this.Location}\nEnds in: {this.EndDate}\n");
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
                    Console.WriteLine($"Želite li izbrisati prisutnost {email}? y/n");
                    var ans = Console.ReadLine();
                    switch (ans)
                    {
                        case "y":
                            var.presence.Clear();
                            var.presence.Add(id, false);
                            Console.WriteLine("Neprisutnost označena!");
                            break;
                        case "n":
                            Console.WriteLine("Odabrali ste ne izbrisati prisutnost");
                            break;
                        default:
                            Console.WriteLine("Pogrešno unesen odabir! Svaka se promjena poništava!");
                            break;
                    }
                }
            }
        }

        public void RemovePersonFromEvent(int id, string email)
        {

            for (var i = 0; i < this.Emails.Count; i++)
            {

                this.Emails[i].presence.Clear();
                this.Emails.Remove(this.Emails[i]);
                Console.WriteLine("Succesfully deleted!");
            }
        }

        public void UpcommingEvents()
        {
            if (this.StartDate > DateTime.Now)
            {
                Console.WriteLine(
                    $"ID: {this.ID}\nEvent name: {this.Name}\nEvent location: {this.Location}\nBegins in: {this.StartDate.Subtract(DateTime.Now).Days} days\n");
                Console.WriteLine("The list of guests:");
                this.Emails.ForEach(person => Console.WriteLine($"{person.Email}, "));
                Console.WriteLine("\n");
            }

        }

        public void GetAbsentAudience()
        {
            Console.WriteLine("The list of audience who were absent:");
            foreach (var person in this.Emails)
            {
                foreach (var presence in person.presence)
                {
                    if (presence.Value.Equals(false))
                        Console.WriteLine($"{person.Email}, ");
                }
            }
        }

        public void GetNonAbsentAudience()
        {
            Console.WriteLine("The list of audience who were participating:");
            foreach (var person in this.Emails)
            {
                foreach (var presence in person.presence)
                {
                    if (presence.Value.Equals(true))
                        Console.WriteLine($"{person.Email}, ");
                }
            }
        }

        public void FinishedEvents()
        {

            var timeSpan = Math.Round(this.EndDate.Subtract(this.StartDate).TotalHours, 1);

            if (this.EndDate < DateTime.Now)
            {
                Console.WriteLine(
                    $"ID: {this.ID}\nEvent name: {this.Name}\nEvent location: {this.Location}\nEnded: {DateTime.Now.Subtract(this.EndDate).Days} days ago\nLasted: {timeSpan} hours\n");
                GetNonAbsentAudience();
                GetAbsentAudience();
                Console.WriteLine("\n");
            }
        }

        public Person FindPersonAndCheckWhetherAvailable(string email)
        {
            foreach (var person in this.Emails)
            {
                if (person.Email.Equals(email))
                {
                    return person;
                }
            }

            return null;
        }
    }
}