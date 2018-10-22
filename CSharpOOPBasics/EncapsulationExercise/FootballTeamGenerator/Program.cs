using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Team> teams = new List<Team>();

        string commands;
        while ((commands = Console.ReadLine()) != "END")
        {
            string[] tokens = commands.Split(';');

            try
            {
                if (tokens[0] == "Team")
                {
                    teams.Add(new Team(tokens[1]));
                }
                else if (tokens[0] == "Add")
                {
                    Team team = teams.FirstOrDefault(t => t.Name == tokens[1]);

                    if (team == null)
                    {
                        throw new ArgumentException($"Team {tokens[1]} does not exist.");
                    }

                    Player player = new Player(tokens[2], int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]));

                    team.AddPlayer(player);
                }
                else if (tokens[0] == "Remove")
                {
                    Team team = teams.FirstOrDefault(t => t.Name == tokens[1]);

                    if (team == null)
                    {
                        throw new ArgumentException($"Team {tokens[1]} does not exist.");
                    }

                    team.RemovePlayer(tokens[2]);
                }
                else if (tokens[0] == "Rating")
                {
                    Team team = teams.FirstOrDefault(t => t.Name == tokens[1]);
                    if (team == null)
                    {
                        throw new ArgumentException($"Team {tokens[1]} does not exist.");
                    }

                    Console.WriteLine($"{team.Name} - {team.Rating}");
                }
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }
        }
    }
}

