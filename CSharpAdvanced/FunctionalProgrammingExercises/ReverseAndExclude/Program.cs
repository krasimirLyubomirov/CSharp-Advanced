using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).Reverse().ToList();
            int divisor = int.Parse(Console.ReadLine());
            Console.WriteLine(String.Join(" ", numbers.Where(n => n % divisor != 0)));
        }
    }
}
