using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<IBirthDate> birthDates = new List<IBirthDate>();

        try
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] info = input.Split();
                string type = info[0];

                if (type == "Citizen")
                {
                    string name = info[1];
                    int age = int.Parse(info[2]);
                    string id = info[3];
                    string birthDate = info[4];

                    Citizen citizen = new Citizen(name, age, id, birthDate);
                    birthDates.Add(citizen);
                }
                else if (type == "Pet")
                {
                    string name = info[1];
                    string birthDate = info[2];

                    Pet pet = new Pet(name, birthDate);
                    birthDates.Add(pet);
                }
            }

            string year = Console.ReadLine();

            foreach (var birthDate in birthDates)
            {
                if (birthDate.BirthDate.EndsWith(year))
                {
                    Console.WriteLine(birthDate.BirthDate);
                }
            }
        }
        catch
        {

        }
    }
}

