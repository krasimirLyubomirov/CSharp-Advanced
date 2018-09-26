using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rangeBorders = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            int startNumber = rangeBorders[0];
            int endNumber = rangeBorders[1] - rangeBorders[0] + 1;
            IEnumerable<int> numbers = Enumerable.Range(startNumber, endNumber);
            Predicate<int> isEven = num => num % 2 == 0;
            PrintChooseNums(numbers, command, isEven);
        }

        private static void PrintChooseNums(IEnumerable<int> numbers, string command, Predicate<int> isEven)
        {
            List<int> result = new List<int>();
            foreach (var number in numbers)
            {   
                if (isEven(number) && command == "even")
                {
                    result.Add(number);
                }
                else if(!isEven(number) && command == "odd")
                {
                    result.Add(number);
                }
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
