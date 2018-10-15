using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int amountOfCars = int.Parse(Console.ReadLine());
        List<Car> cars = new List<Car>();

        for (int car = 0; car < amountOfCars; car++)
        {
            string[] tokens = Console.ReadLine().Split();

            string model = tokens[0];
            int speed = int.Parse(tokens[1]);
            int power = int.Parse(tokens[2]);
            int weight = int.Parse(tokens[3]);
            string type = tokens[4];

            List<Tire> tires = new List<Tire>();

            for (int tire = 5; tire < tokens.Length; tire += 2)
            {
                double pressure = double.Parse(tokens[tire]);
                int age = int.Parse(tokens[tire + 1]);
                Tire tireInfo = new Tire(pressure, age);
                tires.Add(tireInfo);
            }

            Engine engine = new Engine(speed, power);
            Cargo cargo = new Cargo(weight, type);
            Car carInfo = new Car(model, engine, cargo, tires);

            cars.Add(carInfo);
        }

        string command = Console.ReadLine();

        if (command == "fragile")
        {
            foreach (var car in cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1)).Select(c => c.Model))
            {
                Console.WriteLine(car);
            }
        }
        else if (command == "flamable")
        {
            foreach (var car in cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250).Select(c => c.Model))
            {
                Console.WriteLine(car);
            }
        }
    }
}

