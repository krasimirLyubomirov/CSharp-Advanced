using System;

namespace RecursiveFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int fibonacciNumber = int.Parse(Console.ReadLine());

            fibonacci = new long[fibonacciNumber];
            fibonacci[0] = 1;

            if (fibonacciNumber > 1)
            {
                fibonacci[1] = 1;
            }

            Console.WriteLine(RecursiveFibonacci(fibonacciNumber - 1));
        }

        static long[] fibonacci;

        static long RecursiveFibonacci(int number)
        {
            if (fibonacci[number] == 0)
            {
                fibonacci[number] = RecursiveFibonacci(number - 1) + RecursiveFibonacci(number - 2);
            }

            return fibonacci[number];
        }
    }
}
