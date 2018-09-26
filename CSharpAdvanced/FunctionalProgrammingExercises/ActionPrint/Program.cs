using System;

namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Action<string> print = str => Console.WriteLine(str);
            PrintAllNames(names, print);
        }

        private static void PrintAllNames(string[] names, Action<string> print)
        {
            foreach (var name in names)
            {
                print(name);
            }
        }
    }
}
