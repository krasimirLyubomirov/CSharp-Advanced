using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfChemicalCompounds = int.Parse(Console.ReadLine());
            List<string> uniqueChemicalCompounds = new List<string>();

            for (int i = 0; i < numberOfChemicalCompounds; i++)
            {
                string[] chemicalCompounds = Console.ReadLine().Split();

                foreach (var chemicalCompound in chemicalCompounds)
                {
                    uniqueChemicalCompounds.Add(chemicalCompound);
                }
            }

            Console.WriteLine(String.Join(" ", uniqueChemicalCompounds.Distinct().OrderBy(s => s)));
        }
    }
}
