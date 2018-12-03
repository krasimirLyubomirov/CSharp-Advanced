using System;

class Program
{
    static void Main(string[] args)
    {
        Team team = new Team("my team");
        int personsCount = int.Parse(Console.ReadLine());

        for (int counter = 0; counter < personsCount; counter++)
        {
            string[] input = Console.ReadLine().Split();
            try
            {
                string firstName = input[0];
                string lastName = input[1];
                int age = int.Parse(input[2]);
                decimal salary = decimal.Parse(input[3]);
                Person person = new Person(firstName, lastName, age, salary);
                team.AddPlayer(person);
            }
            catch (ArgumentException argumentException)
            {
                Console.WriteLine(argumentException.Message);
            }

        }

        Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
    }
}

