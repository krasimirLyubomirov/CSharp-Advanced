using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        List<ISoldier> soldiers = new List<ISoldier>();

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split();
            string soldierType = tokens[0];
            int id = int.Parse(tokens[1]);
            string firstName = tokens[2];
            string lastName = tokens[3];
            decimal salary = decimal.Parse(tokens[4]);

            ISoldier soldier = null;

            try
            {
                switch (soldierType)
                {
                    case "Private":
                        soldier = new Private(id, firstName, lastName, salary);
                        break;
                    case "LieutenantGeneral":
                        LieutenantGeneral leutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                        for (int i = 5; i < tokens.Length; i++)
                        {
                            int privateId = int.Parse(tokens[i]);
                            ISoldier @private = soldiers.First(p => p.Id == privateId);
                            leutenantGeneral.AddPrivate(@private);
                        }

                        soldier = leutenantGeneral;
                        break;
                    case "Engineer":
                        string engineerCorps = tokens[5];
                        Engineer engineer = new Engineer(id, firstName, lastName, salary, engineerCorps);

                        for (int i = 6; i < tokens.Length; i++)
                        {
                            string partName = tokens[i];
                            int hoursWorked = int.Parse(tokens[++i]);

                            try
                            {
                                IRepair repair = new Repair(partName, hoursWorked);
                                engineer.AddRepair(repair);
                            }
                            catch
                            {

                            }
                        }

                        soldier = engineer;
                        break;
                    case "Commando":
                        string commandoCorps = tokens[5];
                        Commando commando = new Commando(id, firstName, lastName, salary, commandoCorps);

                        for (int i = 6; i < tokens.Length; i++)
                        {
                            string codeName = tokens[i];
                            string missionState = tokens[++i];

                            try
                            {
                                IMission mission = new Mission(codeName, missionState);
                                commando.AddMission(mission);
                            }
                            catch
                            {

                            }
                        }

                        soldier = commando;
                        break;
                    case "Spy":
                        int codeNumber = (int)salary;
                        soldier = new Spy(id, firstName, lastName, codeNumber);
                        break;
                    default:
                        throw new ArgumentException("Invalid soldier type!");
                }

                soldiers.Add(soldier);
            }
            catch
            {

            }
        }

        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }
}
