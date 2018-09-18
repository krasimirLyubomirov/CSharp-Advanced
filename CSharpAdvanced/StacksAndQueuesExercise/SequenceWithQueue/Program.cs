using System;
using System.Collections.Generic;

namespace SequenceWithQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            long currentNumber = long.Parse(Console.ReadLine());
            Queue<long> sequence = new Queue<long>();

            Console.Write($"{currentNumber} ");
            sequence.Enqueue(currentNumber);
            int count = 1;

            while (count < 50)
            {
                currentNumber = sequence.Dequeue();
                Console.Write($"{currentNumber + 1} ");
                sequence.Enqueue(currentNumber + 1);
                count++;

                if (count < 50)
                {
                    Console.Write($"{2 * currentNumber + 1} ");
                    sequence.Enqueue(2 * currentNumber + 1);
                    count++;
                }
                else
                {
                    break;
                }

                if (count < 50)
                {
                    Console.Write($"{currentNumber + 2} ");
                    sequence.Enqueue(currentNumber + 2);
                    count++;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
