using MailCalendar;

var person = new Person();
person.FirstName = "Ivana";
var dictionary = new Dictionary<Guid, bool>();
dictionary.Add(Guid.NewGuid(), true);
person.presence = dictionary;

Console.WriteLine($"Osoba je {person.FirstName} {person.LastName} email je {person.Email}");