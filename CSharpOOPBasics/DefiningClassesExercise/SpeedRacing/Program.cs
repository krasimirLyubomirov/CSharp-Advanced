using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        int numbersOfCars = int.Parse(Console.ReadLine());

        for (int car = 0; car < numbersOfCars; car++)
        {
            string[] tokens = Console.ReadLine().Split();
            string model = tokens[0];
            decimal fuelAmount = decimal.Parse(tokens[1]);
            decimal fuelConsumption = decimal.Parse(tokens[2]);
            Car carInfo = new Car(model, fuelAmount, fuelConsumption);
            cars.Add(carInfo);
        }

        string commands;
        while ((commands = Console.ReadLine()) != "End")
        {
            string[] tokens = commands.Split();
            string model = tokens[1];
            int distance = int.Parse(tokens[2]);
            Car car = cars.First(c => c.Model == model);

            if (car.Drive(distance) == false)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }
    }
}

