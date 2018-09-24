using System;
using System.Collections.Generic;

namespace UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfUsernames = int.Parse(Console.ReadLine());
            List<string> usernames = new List<string>();

            for (int i = 0; i < numberOfUsernames; i++)
            {
                string username = Console.ReadLine();

                if (usernames.Contains(username) == false)
                {
                    usernames.Add(username);
                }
            }

            foreach (var name in usernames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
