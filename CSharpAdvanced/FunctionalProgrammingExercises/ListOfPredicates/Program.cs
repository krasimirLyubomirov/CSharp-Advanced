using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int border = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Func<int, int, bool> filter = (n, d) => n % d == 0;
            SelectAndPrint(border, dividers, filter);
        }

        private static void SelectAndPrint(int border, int[] dividers, Func<int, int, bool> filter)
        {
            List<int> result = new List<int>();
            for (int i = 1; i <= border; i++)
            {
                bool hasPassed = true;
                foreach (var divider in dividers)
                {
                    if (!filter(i, divider))
                    {
                        hasPassed = false;
                    }
                }

                if (hasPassed)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
