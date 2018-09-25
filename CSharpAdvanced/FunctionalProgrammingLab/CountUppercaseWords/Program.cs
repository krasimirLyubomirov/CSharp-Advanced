using System;
using System.Collections.Generic;
using System.Linq;

namespace CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => char.IsUpper(w[0])).ToList();
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
