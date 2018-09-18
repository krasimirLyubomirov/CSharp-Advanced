using System;
using System.Collections.Generic;

namespace HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] children = Console.ReadLine().Split();
            int tossLimit = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(children);

            while (queue.Count > 1)
            {
                for (int i = 1; i < tossLimit; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine($"Removed {queue.Dequeue()}");
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
