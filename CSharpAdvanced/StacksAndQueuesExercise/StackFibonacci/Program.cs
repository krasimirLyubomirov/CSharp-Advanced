using System;
using System.Collections.Generic;

namespace StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Stack<long> fibonacciStack = new Stack<long>();

            fibonacciStack.Push(1);
            fibonacciStack.Push(1);

            for (int i = 2; i < number; i++)
            {
                long previousNumber = fibonacciStack.Pop();
                long nextNumber = fibonacciStack.Peek() + previousNumber;

                fibonacciStack.Push(previousNumber);
                fibonacciStack.Push(nextNumber);
            }

            Console.WriteLine(fibonacciStack.Peek());
        }
    }
}
