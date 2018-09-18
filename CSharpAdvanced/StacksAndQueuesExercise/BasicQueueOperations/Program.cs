using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();

            int numberOfElementsToEnqueue = commands[0];
            int numberOfElementsToDequeue = commands[1];
            int elementInQueue = commands[2];

            for (int i = 0; i < numberOfElementsToEnqueue; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < numberOfElementsToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(elementInQueue))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
