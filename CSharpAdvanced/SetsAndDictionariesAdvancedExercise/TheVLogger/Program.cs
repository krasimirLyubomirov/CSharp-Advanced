using System;
using System.Collections.Generic;
using System.Linq;

namespace TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> followers = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> following = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] informationForWebsite = input.Split();

                string firstVlogger = informationForWebsite[0];
                string command = informationForWebsite[1];

                if (command == "joined")
                {
                    if (followers.ContainsKey(firstVlogger) == false)
                    {
                        followers.Add(firstVlogger, new List<string>());
                        following.Add(firstVlogger, new List<string>());
                    }
                }
                else if (command == "followed")
                {
                    string secondVlogger = informationForWebsite[2];
                    if (followers.ContainsKey(firstVlogger) == false || followers.ContainsKey(secondVlogger) == false)
                    {
                        continue;
                    }
                    else if (firstVlogger == secondVlogger)
                    {
                        continue;
                    }
                    else if (followers[secondVlogger].Contains(firstVlogger))
                    {
                        continue;
                    }

                    followers[secondVlogger].Add(firstVlogger);
                    following[firstVlogger].Add(secondVlogger);
                }
            }

            List<string> vloggers = new List<string>();
            int maxFollowers = 0;

            foreach (var vlogger in followers.OrderByDescending(v => v.Value.Count))
            {
                if (vlogger.Value.Count > maxFollowers)
                {
                    maxFollowers = vlogger.Value.Count;
                }

                if (vlogger.Value.Count == maxFollowers)
                {
                    vloggers.Add(vlogger.Key);
                }
            }

            string name = String.Empty;
            foreach (var vlogger in following.OrderBy(v => v.Value.Count))
            {
                if (vloggers.Contains(vlogger.Key))
                {
                    name = vlogger.Key;
                    break;
                }
            }

            Console.WriteLine($"The V-Logger has a total of {followers.Count} vloggers in its logs.");
            Console.WriteLine($"1. {name} : {followers[name].Count} followers, {following[name].Count} following");

            foreach (var follower in followers[name].OrderBy(f => f))
            {
                Console.WriteLine($"*  {follower}");
            }

            following.Remove(name);
            followers.Remove(name);

            Dictionary<string, int[]> rest = new Dictionary<string, int[]>();

            foreach (var vlogger in followers)
            {
                rest.Add(vlogger.Key, new int[] { vlogger.Value.Count, following[vlogger.Key].Count });
            }

            int count = 2;

            foreach (var vlogger in rest.OrderByDescending(v => v.Value[0]).ThenBy(v => v.Value[1]))
            {
                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value[0]} followers, {vlogger.Value[1]} following");
                count++;
            }
        }
    }
}
