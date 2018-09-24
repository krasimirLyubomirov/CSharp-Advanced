using System;
using System.Collections.Generic;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numberOfLines; i++)
            {
                string[] information = Console.ReadLine().Split(" -> ");
                string color = information[0];
                string[] clothes = information[1].Split(",");

                if (wardrobe.ContainsKey(color) == false)
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                foreach (var cloth in clothes)
                {
                    if (wardrobe[color].ContainsKey(cloth) == false)
                    {
                        wardrobe[color].Add(cloth, 0);
                    }

                    wardrobe[color][cloth]++;
                }
            }

            string[] colorAndItem = Console.ReadLine().Split();
            string searchedColor = colorAndItem[0];
            string searchedItem = colorAndItem[1];

            foreach (var colorsAndClothes in wardrobe)
            {
                Console.WriteLine($"{colorsAndClothes.Key} clothes:");
                foreach (var itemAndCount in colorsAndClothes.Value)
                {
                    if (itemAndCount.Key == searchedItem && colorsAndClothes.Key == searchedColor)
                    {
                        Console.WriteLine($"* {itemAndCount.Key} - {itemAndCount.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {itemAndCount.Key} - {itemAndCount.Value}");
                    }
                }
            }
        }
    }
}
