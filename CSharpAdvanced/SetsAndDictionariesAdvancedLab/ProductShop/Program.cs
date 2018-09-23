using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();

            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] information = input.Split(", ");
                string shop = information[0];
                string product = information[1];
                double price = double.Parse(information[2]);

                if (shops.ContainsKey(shop) == false)
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                if (shops[shop].ContainsKey(product) == false)
                {
                    shops[shop].Add(product, price);
                }

                shops[shop][product] = price;
            }

            foreach (var shop in shops.OrderBy(s => s.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var products in shop.Value)
                {
                    Console.WriteLine($"Product: {products.Key}, Price: {products.Value}");
                }
            }
        }
    }
}
