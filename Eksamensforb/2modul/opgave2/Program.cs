using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Person[] people = new Person[]
        {
            new Person { Name = "Jens Hansen", Age = 45, Phone = "+4512345678" },
            new Person { Name = "Jane Olsen", Age = 22, Phone = "+4543215687" },
            new Person { Name = "Tor Iversen", Age = 35, Phone = "+4587654322" },
            new Person { Name = "Sigurd Nielsen", Age = 31, Phone = "+4512345673" },
            new Person { Name = "Viggo Nielsen", Age = 28, Phone = "+4543217846" },
            new Person { Name = "Rosa Jensen", Age = 23, Phone = "+4543217846" },
        };

        // Find og udskriv personen med mobilnummer “+4543215687”.
        var personWithSpecificPhone = people.FirstOrDefault(p => p.Phone == "+4543215687");
        if (personWithSpecificPhone != null)
        {
            Console.WriteLine($"Person med telefonnummer '+4543215687': {personWithSpecificPhone.Name}");
        }
        else
        {
            Console.WriteLine("Ingen person fundet med telefonnummer '+4543215687'");
        }

        // Vælg alle som er over 30 og udskriv dem.
        var peopleOver30 = people.Where(p => p.Age > 30);
        Console.WriteLine("Personer over 30 år:");
        foreach (var person in peopleOver30)
        {
            Console.WriteLine($"{person.Name}, {person.Age} år");
        }

        // Lav et nyt array med de samme personer, men hvor “+45” er fjernet fra alle telefonnumre.
        var peopleWithoutCountryCode = people.Select(p => new Person
        {
            Name = p.Name,
            Age = p.Age,
            Phone = p.Phone.Replace("+45", "")
        }).ToArray();

        Console.WriteLine("Personer med fjernet landekode fra telefonnummer:");
        foreach (var person in peopleWithoutCountryCode)
        {
            Console.WriteLine($"{person.Name}, {person.Phone}");
        }

        // Generér en string med navn og telefonnummer på de personer, der er yngre end 30, adskilt med komma.
        var peopleUnder30 = people.Where(p => p.Age < 30);
        string namesAndPhonesUnder30 = string.Join(", ", peopleUnder30.Select(p => $"{p.Name}: {p.Phone}"));

        Console.WriteLine("Personer under 30 år (navn: telefonnummer):");
        Console.WriteLine(namesAndPhonesUnder30);
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
}
