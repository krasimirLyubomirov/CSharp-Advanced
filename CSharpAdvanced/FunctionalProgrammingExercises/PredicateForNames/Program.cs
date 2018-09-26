using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();
            Console.WriteLine(String.Join("\n", names.Where(n => n.Length <= nameLength)));
        }
    }
}
