using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int carsPerGreenLight = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            Queue<string> cars = new Queue<string>();
            int totalCars = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    int carsThatCanPass = Math.Min(cars.Count, carsPerGreenLight);

                    for (int i = 0; i < carsThatCanPass; i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        totalCars++;
                    }
                }
                else
                {
                    cars.Enqueue(input);

                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{totalCars} cars passed the crossroads.");
        }
    }
}
