using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int personsCount = int.Parse(Console.ReadLine());
        List<Person> persons = new List<Person>();

        for (int counter = 0; counter < personsCount; counter++)
        {
            string[] input = Console.ReadLine().Split();
            string firstName = input[0];
            string lastName = input[1];
            int age = int.Parse(input[2]);
            Person person = new Person(firstName, lastName, age);
            persons.Add(person);
        }

        persons.OrderBy(p => p.FirstName).ThenBy(p => p.Age).ToList().ForEach(p => Console.WriteLine(p));
    }
}

