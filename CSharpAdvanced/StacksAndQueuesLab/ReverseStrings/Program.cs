using System;
using System.Collections.Generic;

namespace ReverseStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> characters = new Stack<char>();

            foreach (var symbol in input)
            {
                characters.Push(symbol);
            }

            while (characters.Count > 0)
            {
                Console.Write(characters.Pop().ToString());
            }

            Console.WriteLine();
        }
    }
}
