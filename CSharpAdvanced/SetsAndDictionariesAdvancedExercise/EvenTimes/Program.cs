using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int countOfNumbers = int.Parse(Console.ReadLine());
            Dictionary<int, int> numberTimes = new Dictionary<int, int>();

            for (int i = 0; i < countOfNumbers; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (numberTimes.ContainsKey(number) == false)
                {
                    numberTimes.Add(number, 0);
                }

                numberTimes[number]++;
            }

            foreach (var number in numberTimes.Where(n => n.Value % 2 == 0))
            {
                Console.WriteLine(number.Key);
            }
        }
    }
}
