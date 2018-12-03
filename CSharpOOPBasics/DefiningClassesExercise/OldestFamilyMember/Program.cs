using System;

public class Program
{
    static void Main(string[] args)
    {
        int numberOfPeople = int.Parse(Console.ReadLine());
        Family family = new Family();

        for (int i = 0; i < numberOfPeople; i++)
        {
            string[] personInfo = Console.ReadLine().Split();
            string personName = personInfo[0];
            int personAge = int.Parse(personInfo[1]);

            Person person = new Person(personName, personAge);
            family.AddMember(person);
        }

        Person oldestPerson = family.GetOldestMember();
        Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
    }
}

