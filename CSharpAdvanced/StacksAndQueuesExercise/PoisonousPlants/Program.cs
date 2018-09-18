using System;
using System.Collections.Generic;
using System.Linq;

namespace PoisonousPlants
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPlants = int.Parse(Console.ReadLine());
            int[] plants = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] daysPlantsDie = new int[numberOfPlants];
            Stack<int> previousPlants = new Stack<int>();

            previousPlants.Push(0);

            for (int i = 1; i < numberOfPlants; i++)
            {
                int lastDay = 0;
                while (previousPlants.Count() > 0 && plants[previousPlants.Peek()] >= plants[i])
                {
                    lastDay = Math.Max(lastDay, daysPlantsDie[previousPlants.Pop()]);
                }

                if (previousPlants.Count() > 0)
                {
                    daysPlantsDie[i] = lastDay + 1;
                }

                previousPlants.Push(i);
            }

            Console.WriteLine(daysPlantsDie.Max());
        }
    }
}
