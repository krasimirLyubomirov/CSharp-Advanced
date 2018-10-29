using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<Soldiers> soldiers = new List<Soldiers>();

        try
        {
            string commands;
            while ((commands = Console.ReadLine()) != "End")
            {
                string[] info = commands.Split();

                if (info.Length == 3)
                {
                    string name = info[0];
                    int age = int.Parse(info[1]);
                    string id = info[2];

                    Soldiers citizen = new Soldiers(name, age, id);
                    soldiers.Add(citizen);
                }
                else if (info.Length == 2)
                {
                    string model = info[0];
                    string id = info[1];

                    Soldiers robot = new Soldiers(model, id);
                    soldiers.Add(robot);
                }
            }

            string lastDigitOfFakeId = Console.ReadLine();

            foreach (var soldier in soldiers)
            {
                if (soldier.Id.EndsWith(lastDigitOfFakeId))
                {
                    Console.WriteLine(soldier.Id);
                }
            }
        }
        catch
        {
            
        }
    }
}

