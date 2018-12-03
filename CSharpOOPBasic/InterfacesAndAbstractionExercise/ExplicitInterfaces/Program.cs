using System;

public class Program
{
    public static void Main()
    {
        string commands;
        while ((commands = Console.ReadLine()) != "End")
        {
            string[] info = commands.Split();
            string name = info[0];
            string country = info[1];
            int age = int.Parse(info[2]);

            Citizen citizen = new Citizen(name, country, age);

            Console.WriteLine(citizen.GetName());
            Console.WriteLine(((IResident)citizen).GetName());
        }
    }
}

