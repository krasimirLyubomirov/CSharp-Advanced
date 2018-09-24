using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lengthOfTwoSets = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstLength = lengthOfTwoSets[0];
            int secondLength = lengthOfTwoSets[1];

            List<int> firstSet = new List<int>();
            List<int> secondSet = new List<int>();
            List<int> containsNumbers = new List<int>();

            for (int i = 0; i < firstLength; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }

            for (int i = 0; i < secondLength; i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }

            foreach (var number in firstSet)
            {
                if (secondSet.Contains(number))
                {
                    containsNumbers.Add(number);
                }
            }

            Console.WriteLine(String.Join(" ", containsNumbers.Distinct()));
        }
    }
}
