﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();
            Console.WriteLine(names.FirstOrDefault(name => name.ToCharArray().Sum(n => n) >= sum));
        }
    }
}
