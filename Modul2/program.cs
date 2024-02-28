using System;
using System.Xml.Linq;

Person[] people = new Person[]
{
    new Person { Name = "Jens Hansen", Age = 45, Phone = "+4512345678" },
    new Person { Name = "Jane Olsen", Age = 22, Phone = "+4543215687" },
    new Person { Name = "Tor Iversen", Age = 35, Phone = "+4587654322" },
    new Person { Name = "Sigurd Nielsen", Age = 31, Phone = "+4512345673" },
    new Person { Name = "Viggo Nielsen", Age = 28, Phone = "+4543217846" },
    new Person { Name = "Rosa Jensen", Age = 23, Phone = "+4543217846" },
};


//Opg1.1
var peopleAgeSum = people.Sum(p => p.Age);
Console.WriteLine(peopleAgeSum);

//Opg1.2 (Virker ikke perfekt, tager hele navnet)
var antalNielsen = people.Count(p => p.Name.Contains ("Nielsen"));
Console.WriteLine(antalNielsen);

//Opg1.3
var oldestPerson = people.Max(p => p.Age);
Console.WriteLine(oldestPerson);

//Opg2.1
var thisPhone = people.FirstOrDefault(p => p.Phone == "+4543215687");
Console.WriteLine($"{thisPhone.Name}");

//Opg2.2
var overTredive = string.Join(", ", people.Where(p => p.Age > 30).Select(p => p.Name));
Console.WriteLine("de er godt nok gamle: " + overTredive);

//Opg2.3 SLet ikke færdig, brug noget af det fra peopleNew nedenunder
var peopleNew = people.Select(p => new Person {
   Name = p.Name,
   Age = p.Age,
   Phone = p.Phone.Replace("+45", "")
});
peopleNew.ToList().ForEach(p => Console.WriteLine(p.Name + " " + p.Phone));


class Person {
    public string Name { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
}