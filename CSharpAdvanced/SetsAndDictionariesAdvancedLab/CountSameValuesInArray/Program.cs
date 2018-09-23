using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, int> numberTimes = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (numberTimes.ContainsKey(number) == false)
                {
                    numberTimes.Add(number, 1);
                }
                else
                {
                    numberTimes[number]++;
                }
            }

            foreach (var times in numberTimes)
            {
                Console.WriteLine($"{times.Key} - {times.Value} times");
            }
        }
    }
}
