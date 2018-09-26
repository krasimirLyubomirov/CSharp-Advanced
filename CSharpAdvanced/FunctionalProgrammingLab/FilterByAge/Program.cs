using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleCount = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>();

            for (int i = 0; i < peopleCount; i++)
            {
                string[] nameAndAge = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                people.Add(nameAndAge[0], int.Parse(nameAndAge[1]));
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            Func<int, bool> filter = CreateFilter(condition, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            PrintPeople(people, filter, printer);
        }

        private static void PrintPeople(Dictionary<string, int> people, Func<int, bool> filter, 
            Action<KeyValuePair<string, int>> printer)
        {
            foreach (var person in people)
            {
                if (filter(person.Value))
                {
                    printer(person);
                }
            }
        }

        static Func<int, bool> CreateFilter(string condition, int age)
        {
            if (condition == "younger")
            {
                return x => x < age;
            }
            else
            {
                return x => x >= age;
            }
        }

        static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return x => Console.WriteLine(x.Key);
                case "age":
                    return x => Console.WriteLine(x.Value);
                case "name age":
                    return x => Console.WriteLine($"{x.Key} - {x.Value}");
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
