using System;
using System.Linq;
using System.Collections.Generic;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> users = new Dictionary<string, Dictionary<string, int>>();

            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] contestData = input.Split(":");
                string nameContest = contestData[0];
                string passwordContest = contestData[1];

                contests.Add(nameContest, passwordContest);
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] userData = input.Split("=>");
                string nameContest = userData[0];
                string passwordContest = userData[1];
                string username = userData[2];
                int points = int.Parse(userData[3]);

                if (contests.ContainsKey(nameContest) == false)
                {
                    continue;
                }

                if (contests[nameContest].Contains(passwordContest) == false)
                {
                    continue;
                }

                if (users.ContainsKey(username) == false)
                {
                    users.Add(username, new Dictionary<string, int>());
                }

                if (users[username].ContainsKey(nameContest) == false)
                {
                    users[username].Add(nameContest, 0);
                }

                if (users[username][nameContest] < points)
                {
                    users[username][nameContest] = points;
                }
            }

            KeyValuePair<string, Dictionary<string, int>> bestCandidate = users.OrderByDescending(u => u.Value.Values.Sum()).FirstOrDefault();
            int bestCandidateTotalPoints = bestCandidate.Value.Values.Sum();
            Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidateTotalPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in users.OrderBy(u => u.Key))
            {
                Console.WriteLine($"{user.Key}");
                foreach (var contest in user.Value.OrderByDescending(u => u.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
