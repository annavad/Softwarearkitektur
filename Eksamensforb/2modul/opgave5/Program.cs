using System;
using System.Linq;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }

    public override string ToString()
    {
        return $"{Name}, {Age} år, {Phone}";
    }
}

public class BubbleSort
{
    // Bytter om på to elementer i et array
    private static void Swap(Person[] array, int i, int j)
    {
        Person temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    // Laver sortering på array med Bubble Sort. 
    // compareFn bruges til at sammenligne to personer med.
    public static void Sort(Person[] array, Func<Person, Person, int> compareFn)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            for (int j = 0; j <= i - 1; j++)
            {
                // Laver en ombytning, hvis to personer står forkert sorteret
                if (compareFn(array[j], array[j + 1]) > 0)
                {
                    Swap(array, j, j + 1);
                }
            }
        }
    }
}

public class Program
{
    // Højere ordens funktion der returnerer en ny sorteringsfunktion
    public static Action<Person[]> CreateSorter(Func<Person, Person, int> compareFn)
    {
        return (Person[] people) =>
        {
            BubbleSort.Sort(people, compareFn);
        };
    }

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

        // Der laves en ny sorterings-funktion hvor der sammenlignes på alder
        var PeopleSortAge = CreateSorter((person1, person2) => person1.Age - person2.Age);
        
        // Den nye funktion bruges til at sortere et array
        PeopleSortAge(people);

        // Det sorterede array udskrives med LINQ så vi kan se at det virker
        Console.WriteLine("Sorteret efter alder:");
        people.ToList().ForEach(p => Console.WriteLine(p.Age + " " + p.Name));
        Console.WriteLine();

        // Der laves en ny sorterings-funktion hvor der sammenlignes på navn
        var PeopleSortName = CreateSorter((person1, person2) => string.Compare(person1.Name, person2.Name, StringComparison.Ordinal));
        
        // Den nye funktion bruges til at sortere et array
        PeopleSortName(people);

        // Det sorterede array udskrives med LINQ så vi kan se at det virker
        Console.WriteLine("Sorteret efter navn:");
        people.ToList().ForEach(p => Console.WriteLine(p.Name + " " + p.Age));
        Console.WriteLine();

        // Der laves en ny sorterings-funktion hvor der sammenlignes på telefonnummer
        var PeopleSortPhone = CreateSorter((person1, person2) => string.Compare(person1.Phone, person2.Phone, StringComparison.Ordinal));
        
        // Den nye funktion bruges til at sortere et array
        PeopleSortPhone(people);

        // Det sorterede array udskrives med LINQ så vi kan se at det virker
        Console.WriteLine("Sorteret efter telefonnummer:");
        people.ToList().ForEach(p => Console.WriteLine(p.Phone + " " + p.Name));
    }
}
