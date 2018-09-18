using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();
            Stack<int> maxStack = new Stack<int>();

            maxStack.Push(int.MinValue);

            for (int i = 0; i < commandsCount; i++)
            {
                int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();

                switch (command[0])
                {
                    case 1:
                        int element = command[1];
                        stack.Push(element);
                        if (element >= maxStack.Peek())
                        {
                            maxStack.Push(element);
                        }
                        break;
                    case 2:
                        int poppedElement = stack.Pop();
                        if (maxStack.Peek() == poppedElement)
                        {
                            maxStack.Pop();
                        }
                        break;
                    case 3:
                        int maxElement = maxStack.Peek();
                        Console.WriteLine(maxElement);
                        break;
                }
            }
        }
    }
}
