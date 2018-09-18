using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int pumpCount = int.Parse(Console.ReadLine());
            Queue<int[]> queue = new Queue<int[]>();

            for (int i = 0; i < pumpCount; i++)
            {
                int[] pump = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queue.Enqueue(pump);
            }

            for (int currentStart = 0; currentStart < queue.Count - 1; currentStart++)
            {
                int fuel = 0;
                bool isSolution = true;

                for (int pumpPassed = 0; pumpPassed < queue.Count; pumpPassed++)
                {
                    int[] currentPump = queue.Dequeue();
                    int pumpFuel = currentPump[0];
                    int nextPumpDistance = currentPump[1];
                    queue.Enqueue(currentPump);

                    fuel += pumpFuel - nextPumpDistance;
                    if (fuel < 0)
                    {
                        currentStart += pumpPassed;
                        isSolution = false;
                        break;
                    }
                }

                if (isSolution)
                {
                    Console.WriteLine(currentStart);
                    Environment.Exit(0);
                }
            }
        }
    }
}
