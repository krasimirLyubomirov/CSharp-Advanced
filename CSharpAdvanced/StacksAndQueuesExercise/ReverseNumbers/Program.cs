using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Stack<int> stackNumbers = new Stack<int>(numbers);

            Console.WriteLine(String.Join(" ", stackNumbers));
        }
    }
}
