using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<IBuyer> buyers = new List<IBuyer>();

        int numberOfPeople = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfPeople; i++)
        {
            string[] info = Console.ReadLine().Split();

            if (info.Length == 4)
            {
                string name = info[0];
                int age = int.Parse(info[1]);
                string id = info[2];
                string birthDate = info[3];

                Citizen citizen = new Citizen(name, age, id, birthDate);
                buyers.Add(citizen);
            }
            else if (info.Length == 3)
            {
                string name = info[0];
                int age = int.Parse(info[1]);
                string group = info[2];

                Rebel rebel = new Rebel(name, age, group);
                buyers.Add(rebel);
            }
        }

        string nameOfPerson;
        while ((nameOfPerson = Console.ReadLine()) != "End")
        {
            IBuyer buyer = buyers.SingleOrDefault(b => b.Name == nameOfPerson);

            if (buyer != null)
            {
                buyer.BuyFood();
            }
        }

        Console.WriteLine(buyers.Sum(b => b.Food));
    }
}

