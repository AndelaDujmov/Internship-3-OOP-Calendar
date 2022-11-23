using MailCalendar.Classes;

class Program
{
    static void Main(string[] args)
    {
        
        var emails = new System.Collections.Generic.List<string>(){ "renata.jelic@gmail.com", "marijana.jelic@gmail.com" };
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
        
        EventList.Add(new Event(1)
        {
            Emails = new List<Person>(){PersonList[1], PersonList[0]},
            EndDate = DateTime.Now.AddDays(27),
            Location = "Split",
            StartDate = DateTime.Now.AddDays(-12),
            Name = "Programiranje u Javi"
        });
        
        EventList.Add(new Event(2)
        {
            Emails = new List<Person>(){PersonList[2], PersonList[3]},
            EndDate = DateTime.Now.AddDays(67),
            Location = "Split",
            StartDate = DateTime.Now.AddDays(-2),
            Name = "Programiranje u C#"
        });
        
        EventList.Add(new Event(3)
        {
            Emails = new List<Person>(){PersonList[4], PersonList[5]},
            EndDate = DateTime.Now.AddDays(123),
            Location = "Split",
            StartDate = DateTime.Now.AddDays(12),
            Name = "Programiranje u Kotlinu"
        });
        EventList.Add(new Event(4)
        {
            Emails = new List<Person>(){PersonList[6]},
            EndDate = DateTime.Now.AddDays(13),
            Location = "Zagreb",
            StartDate = DateTime.Now.AddDays(5),
            Name = "Uvod u robotiku"
        });

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
                    Console.WriteLine("Izabrali ste opciju Aktivni eventi");
                    EventList.ForEach(even => even.PrintActiveEvents());
                    SubmenuA();
                    break;
                case 'b':
                    Console.Clear();
                    Console.WriteLine("Izabrali ste opciju Nadolazeći eventi");
                    EventList.ForEach(even => even.UpcommingEvents());
                    SubmenuB();
                    break;
                case 'c':
                    Console.Clear();
                    Console.WriteLine("Izabrali ste opciju Završeni eventi");
                    break;
                case 'd':
                    Console.Clear();
                    Console.WriteLine("Izabrali ste opciju Kreiraj event");
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
                EventList.ForEach(even => even.NoteAbsents(even.ID, "marijana.relja@gmail.com"));
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
                   
                    break;
                case '0':
                    Console.Clear();
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
                    EventList.Remove(EventList[i]);
                    Console.WriteLine("Event uspješno izbrisan!");
                    flag = 1;
                }
            }
            
            if(flag is 0)
                Console.WriteLine("Event ne postoji!");
        }
    }
}