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

        // Sortering efter alder med BubbleSort
        BubbleSort.Sort(people, (p1, p2) => p1.Age.CompareTo(p2.Age));
        Console.WriteLine("Sorteret efter alder (BubbleSort):");
        foreach (var person in people)
        {
            Console.WriteLine(person);
        }
        Console.WriteLine();

        // Sortering efter alder med LINQ
        var sortedByAge = people.OrderBy(p => p.Age).ToArray();
        Console.WriteLine("Sorteret efter alder (LINQ):");
        foreach (var person in sortedByAge)
        {
            Console.WriteLine(person);
        }
        Console.WriteLine();

        // Sortering efter navn med LINQ
        var sortedByName = people.OrderBy(p => p.Name).ToArray();
        Console.WriteLine("Sorteret efter navn (LINQ):");
        foreach (var person in sortedByName)
        {
            Console.WriteLine(person);
        }
        Console.WriteLine();

        // Sortering efter telefonnummer med LINQ
        var sortedByPhone = people.OrderBy(p => p.Phone).ToArray();
        Console.WriteLine("Sorteret efter telefonnummer (LINQ):");
        foreach (var person in sortedByPhone)
        {
            Console.WriteLine(person);
        }
    }
}
