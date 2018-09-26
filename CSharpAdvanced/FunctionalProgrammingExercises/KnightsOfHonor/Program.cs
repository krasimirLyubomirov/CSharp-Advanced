using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var name in names)
            {
                Console.WriteLine($"Sir {name}");
            }
        }
    }
}
