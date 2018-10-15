using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int countPerson = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();

        for (int i = 0; i < countPerson; i++)
        {
            string[] personInfo = Console.ReadLine().Split();
            string name = personInfo[0];
            int age = int.Parse(personInfo[1]);
            Person person = new Person(name, age);
            persons.Add(person);
        }

        foreach (var person in persons.OrderBy(p => p.Name).Where(p => p.Age > 30))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}

