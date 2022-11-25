using MailCalendar.Classes;

class Program
{
    static void Main(string[] args)
    {
        
        var emails = new List<string>(){ "renata.jelic@gmail.com", "marijana.jelic@gmail.com" };
        var PersonList = new List<Person>();
        var EventList = new List<Event>();

        PersonList.Add(new Person("Ivcevic", "renata.ivcevic@gmail.com")
        {
            FirstName = "Renata"
        });
        PersonList.Add(new Person("Jelic", "anamarija.jelic@gmail.com")
        {
            FirstName = "Anamarija"
        });
        PersonList.Add(new Person("Dujmov", "andela.dujmov@gmail.com")
        {
            FirstName = "Andela"
        });
        PersonList.Add(new Person("Alenkic", "milanka.alenkic@gmail.com")
        {
            FirstName = "Milanka"
        });
        PersonList.Add(new Person("Matic", "mate.matic@gmail.com")
        {
            FirstName = "Mate"
        });
        PersonList.Add(new Person("Relja", "marijana.relja@gmail.com")
        {
            FirstName = "Marijana"
        });
        PersonList.Add(new Person("Ruzic", "zoran.ruzic@gmail.com")
        {
            FirstName = "Zoran"
        });
        PersonList.Add(new Person("Kavur", "petra.kavur@gmail.com")
        {
            FirstName = "Petra"
        });

        PersonList.Add(new Person("Kraljevic", "miro.kraljevic@gmail.com")
        {
            FirstName = "Miro"
        });

        PersonList.Add(new Person("Saska", "mara.saska@gmail.com")
        {
            FirstName = "Mara"
        });
        
        var event1 = new Event(1)
        {
            EndDate = DateTime.Now.AddDays(27),
            Location = "Split",
            StartDate = DateTime.Now.AddDays(-12),
            Name = "Programiranje u Javi"
        };
        
      
        
        var event2 = new Event(2)
        {
            EndDate = DateTime.Now.AddDays(-1),
            Location = "Split",
            StartDate = DateTime.Now.AddDays(-24),
            Name = "Programiranje u C#"
        };
        
        var event3 = new Event(3)
        {
            EndDate = DateTime.Now.AddDays(123),
            Location = "Split",
            StartDate = DateTime.Now.AddDays(12),
            Name = "Programiranje u Kotlinu"
        };
        
        var event4 = new Event(4)
        {
            EndDate = DateTime.Now.AddDays(13),
            Location = "Zagreb",
            StartDate = DateTime.Now.AddDays(5),
            Name = "Uvod u robotiku"
        };
        
        var event5 = new Event(5)
        {
            EndDate = DateTime.Now.AddDays(-3),
            Location = "Varaždin",
            StartDate = DateTime.Now.AddDays(-15),
            Name = "Uvod u Njemački jezik"
        };
        event1.SetEventEmails(new List<Person>(){ PersonList[0], PersonList[2]});
        EventList.Add(event1);
        event2.SetEventEmails(new List<Person>(){ PersonList[1], PersonList[3]});
        EventList.Add(event2);
        event3.SetEventEmails(new List<Person>(){ PersonList[4], PersonList[5]});
        EventList.Add(event3);
        event4.SetEventEmails(new List<Person>(){ PersonList[6], PersonList[7]});
        EventList.Add(event4);
        event5.SetEventEmails(new List<Person>(){PersonList[8], PersonList[9]});
        EventList.Add(event5);
        
        MainMenu();
        
        void MainMenu()
        {
            Console.WriteLine("Dobrodošli na Mail Kalendar!");
            Console.WriteLine("Odaberite jednu od sljedećih opcija!");
            Console.WriteLine("a - Aktivni eventi");
            Console.WriteLine("b - Nadolazeći eventi");
            Console.WriteLine("c - Završeni eventi");
            Console.WriteLine("d - Kreirajte event");
            Console.WriteLine("0 - Izlaz iz programa");

            char choice;
            char.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 'a':
                    Console.Clear();
                    Console.WriteLine("Izabrali ste opciju Aktivni eventi"); //napraviti opciju da korisnik može kreirati novog korisnika
                    EventList.ForEach(even => even.PrintActiveEvents());
                    SubmenuA();
                    break;
                case 'b':
                    Console.Clear();
                    Console.WriteLine("Izabrali ste opciju Nadolazeći eventi");
                    EventList.ForEach(even => even.UpcommingEvents()); // eventualno staviti tu za neki submenu!!!!!!!!!!!!!!11
                    SubmenuB();
                    break;
                case 'c':
                    Console.Clear();
                    Console.WriteLine("Izabrali ste opciju Završeni eventi");
                    EventList.ForEach(even => even.FinishedEvents());
                    break;
                case 'd':
                    Console.Clear();
                    Console.WriteLine("Izabrali ste opciju Kreiraj event");
                    Console.WriteLine("Želite li kreirati novi element? y/n");
                    var nas = Console.ReadLine();
                    if(nas is "y")
                        CreateEvent();
                    break;
                case '0': 
                    Console.WriteLine("Izabrali ste opciju Izlaz iz programa");
                    break;
                default:
                    Console.WriteLine("Niste odabrali ni jednu od ponuđenih opcija!");
                    break;
            }
        }

        void SubmenuA()
        {
            Console.WriteLine("a - Zabilježi neprisutnosti");
            Console.WriteLine("0 - Povratak na glavni meni");

            
            char ans;
            char.TryParse(Console.ReadLine(), out ans);

            if (ans.Equals('a'))
            {
                Console.Clear();
                Console.WriteLine("Odabrali ste opciju zabilježavanja neprisutnosti osobe!");
                Console.WriteLine("Unesite mail osobe koja neće biti prisutna:");
                var email = Console.ReadLine();
                EventList.ForEach(even => even.NoteAbsents(even.ID, email));
                MainMenu();
            }
            else if(ans.Equals('0')){
                Console.Clear();
                MainMenu();
            }
        }

        void SubmenuB()
        {
            Console.WriteLine("a - Izbriši event");
            Console.WriteLine("b - Ukloni osobe s eventa");
            Console.WriteLine("0 - Povratak na glavni meni");
            
            char ans;
            char.TryParse(Console.ReadLine(), out ans);

            switch (ans)
            {
                case 'a':
                    Console.Clear();
                    Console.WriteLine("Odabrali ste opciju brisanja eventa!");
                    Console.WriteLine("Unesite broj eventa kojeg zelite izbrisati!");
                    var broj = 0;
                    int.TryParse(Console.ReadLine(), out broj);
                    DeleteEvent(broj);
                    break;
                case 'b':
                    Console.Clear();
                    Console.WriteLine("Odabrali ste opciju uklanjanja osobe s eventa!");
                    Console.WriteLine("Unesite email osobe koju biste izbrisali iz eventa!");
                    var email = Console.ReadLine();
                    var flag = 0;
                    
                    foreach (var events in EventList)
                    {
                        if(CheckIfPersonExistsInEventList(email, events))
                        {
                            events.RemovePersonFromEvent(events.ID, email);
                            flag = 1;
                        }
                    }
                    
                    if(flag is 0) Console.WriteLine("Person you searched for does not exist on the event list");
                    MainMenu();
                    break;
                case '0':
                    Console.Clear();
                    MainMenu();
                    break;
            }
        }
        
        void DeleteEvent(int id)
        {
            var flag = 0;

            for (int i = 0; i < EventList.Count; i++)
            {
                if (EventList[i].ID.Equals(id))
                {
                    if (EventList[i].EndDate < DateTime.Now)
                    {
                        flag = 1;
                        Console.WriteLine($"Event {EventList[i].Name} je završen te se ne može izbrisati!");
                    }
                    else
                    {
                        EventList[i].Emails.ForEach(eve => eve.presence.Clear());
                        EventList.Remove(EventList[i]);
                        Console.WriteLine("Event uspješno izbrisan!");
                        flag = 1;
                    }
                }
            }
            if(flag is 0)
                Console.WriteLine("Event ne postoji!");
        }


        bool CheckIfPersonExistsInEventList(string email, Event eve)
        {
            foreach (var per in eve.Emails)
            {
                if (per.Email.Equals(email))
                    return true;
               
            }
            return false;
        }

        void CreateEvent()
        {
            Console.WriteLine("Unesite naziv eventa!");
            var name = Console.ReadLine();
            Console.WriteLine("Unesite lokaciju eventa!");
            var location = Console.ReadLine();
            Console.WriteLine("Unesite datum početka eventa u formatu YYYY-MM-DD!");
            var start = new DateTime();
            DateTime.TryParse(Console.ReadLine(), out start);
            Console.WriteLine("Unesite datum završetka eventa u formatu YYYY-MM-DD!");
            var end = new DateTime();
            DateTime.TryParse(Console.ReadLine(), out end);

            var eventCreated = new Event(name, location, start, end);
            var listEmails = new List<Person>();
            string email = null;
            while (email != "q")
            {
                Console.WriteLine("Unesite emailove osoba koje želite dodati u event!");
                Console.WriteLine("U slučaju da ste dodali potreban broj osoba stisnite q");
                email = Console.ReadLine();

                if (!TryCheckIfEmailIsValid(email))
                {
                    Console.WriteLine("Email nije validan!");
                    continue;
                }

                else
                {
                    Console.WriteLine("Email je validan!");
                    var person = new Person();

                    EventList.ForEach(eveent =>
                    {
                        person = eveent.FindPersonAndCheckWhetherAvailable(email);
                        if (person is not null)
                            Console.WriteLine($"{person.FirstName} {person.LastName}");
                    });
                    
                    if (!CheckWhetherPersonAvailable(person))
                    {
                        Console.WriteLine("Nemoguće dodati na event osobu koja sudjeluje u drugom eventu!");
                        continue;
                    }
                    else
                        listEmails.Add(person);
                }
            }
            eventCreated.SetEventEmails(listEmails);
            Console.WriteLine($"event {eventCreated.Name} uspješno kreiran na datum {eventCreated.StartDate.DayOfWeek}, {eventCreated.StartDate.ToShortDateString()}");
        }

        bool CheckWhetherPersonAvailable(Person person)
        {
            foreach (var eve in EventList)
            {
                if (eve.Emails.Contains(person))
                {
                    if (eve.EndDate > DateTime.Now)
                        return false;
                    else
                        return true;
                }
            }

            return false;
        }

        bool TryCheckIfEmailIsValid(string email)
        {
            if (email.Contains("@") && email.Contains(".com"))
                return true;
            return false;
        }
    }
}
