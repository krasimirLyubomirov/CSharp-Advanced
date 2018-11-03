using System;

public class Program
{
    public static void Main()
    {
        string[] carInformation = Console.ReadLine().Split();
        double carFuelQuantity = double.Parse(carInformation[1]);
        double carLitersPerKm = double.Parse(carInformation[2]);
        Vehicle car = new Car(carFuelQuantity, carLitersPerKm);

        string [] truckInformation = Console.ReadLine().Split();
        double truckFuelQuantity = double.Parse(truckInformation[1]);
        double truckLitersPerKm = double.Parse(truckInformation[2]);
        Vehicle truck = new Truck(truckFuelQuantity, truckLitersPerKm);

        int numberOfCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfCommands; i++)
        {
            string[] commands = Console.ReadLine().Split();
            string command = commands[0];
            string vehicle = commands[1];
            double value = double.Parse(commands[2]);

            switch (vehicle)
            {
                case nameof(Car):
                    switch (command)
                    {
                        case "Drive":
                            Console.WriteLine(car.Drive(value));
                            break;
                        case "Refuel":
                            car.Refuel(value);
                            break;
                    }
                    break;
                case nameof(Truck):
                    switch (command)
                    {
                        case "Drive":
                            Console.WriteLine(truck.Drive(value));
                            break;
                        case "Refuel":
                            truck.Refuel(value);
                            break;
                    }
                    break;
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
    }
}

