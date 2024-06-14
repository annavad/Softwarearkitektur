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

        // Udregner den samlede alder for alle mennesker.
        int totalAge = people.Sum(person => person.Age);

        Console.WriteLine($"Den samlede alder for alle mennesker er {totalAge}");

         // Tæller hvor mange der hedder "Nielsen"
        int countNielsen = people.Count(person => person.Name.Contains("Nielsen"));

        Console.WriteLine($"Antallet af personer der hedder 'Nielsen' er {countNielsen}");

        // Find den ældste person
        Person oldestPerson = people.OrderByDescending(person => person.Age).FirstOrDefault();

        if (oldestPerson != null)
        {
            Console.WriteLine($"Den ældste person er {oldestPerson.Name}, {oldestPerson.Age} år gammel");
        }
        else
        {
            Console.WriteLine("Ingen personer fundet.");
        }
    }
}

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
}
