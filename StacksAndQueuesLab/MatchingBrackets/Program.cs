using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> stackOpenBracketIndexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stackOpenBracketIndexes.Push(i);
                }

                if (input[i] == ')')
                {
                    int openBracketIndex = stackOpenBracketIndexes.Pop();
                    int length = i - openBracketIndex + 1;
                    Console.WriteLine(input.Substring(openBracketIndex, length));
                }
            }
        }
    }
}
