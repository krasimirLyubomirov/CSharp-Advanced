using System;
using System.Collections.Generic;

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
            decimal salary = decimal.Parse(input[3]);
            Person person = new Person(firstName, lastName, age, salary);
            persons.Add(person);
        }

        decimal percentage = decimal.Parse(Console.ReadLine());
        persons.ForEach(p => p.IncreaseSalary(percentage));
        persons.ForEach(p => Console.WriteLine(p));
    }
}

