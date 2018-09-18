using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] elements = input.Split();
            Stack<string> stack = new Stack<string>();

            for (int i = elements.Length - 1; i >= 0; i--)
            {
                stack.Push(elements[i]);
            }

            while (stack.Count > 1)
            {
                int leftOperand = int.Parse(stack.Pop());
                string operation = stack.Pop();
                int rightOperand = int.Parse(stack.Pop());

                if (operation == "+")
                {
                    stack.Push((leftOperand + rightOperand).ToString());
                }
                else if (operation == "-")
                {
                    stack.Push((leftOperand - rightOperand).ToString());
                }
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
