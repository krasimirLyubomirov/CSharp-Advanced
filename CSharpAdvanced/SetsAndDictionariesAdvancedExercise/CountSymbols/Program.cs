using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            SortedDictionary<char, int> charAndTimes = new SortedDictionary<char, int>();

            foreach (var symbol in text)
            {
                if (charAndTimes.ContainsKey(symbol) == false)
                {
                    charAndTimes.Add(symbol, 0);
                }

                charAndTimes[symbol]++;
            }

            foreach (var charAndTime in charAndTimes.Distinct())
            {
                Console.WriteLine($"{charAndTime.Key}: {charAndTime.Value} time/s");
            }
        }
    }
}
