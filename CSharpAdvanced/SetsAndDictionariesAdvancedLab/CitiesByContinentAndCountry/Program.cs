using System;
using System.Collections.Generic;
using System.Linq;

namespace CitiesByContinentAndCountry
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();
            int numberOfContinents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfContinents; i++)
            {
                string[] information = Console.ReadLine().Split();
                string continent = information[0];
                string country = information[1];
                string city = information[2];

                if (continents.ContainsKey(continent) == false)
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }

                if (continents[continent].ContainsKey(country) == false)
                {
                    continents[continent].Add(country, new List<string>());
                }

                continents[continent][country].Add(city);
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var countriesAndCities in continent.Value)
                {
                    Console.WriteLine($"  {countriesAndCities.Key} -> {string.Join(", ", countriesAndCities.Value)}");
                }
            }
        }
    }
}
