using System;

public class Program
{
    public static void Main()
    {
        string[] carInformation = Console.ReadLine().Split();
        double carFuelQuantity = double.Parse(carInformation[1]);
        double carLitersPerKm = double.Parse(carInformation[2]);
        double carTankCapacity = double.Parse(carInformation[3]);
        Vehicle car = new Car(carFuelQuantity, carLitersPerKm, carTankCapacity);

        string[] truckInformation = Console.ReadLine().Split();
        double truckFuelQuantity = double.Parse(truckInformation[1]);
        double truckLitersPerKm = double.Parse(truckInformation[2]);
        double truckTankCapacity = double.Parse(truckInformation[3]);
        Vehicle truck = new Truck(truckFuelQuantity, truckLitersPerKm, truckTankCapacity);

        string[] busInformation = Console.ReadLine().Split();
        double busFuelQuantity = double.Parse(busInformation[1]);
        double busLitersPerKm = double.Parse(busInformation[2]);
        double busTankCapacity = double.Parse(busInformation[3]);
        Vehicle bus = new Bus(busFuelQuantity, busLitersPerKm, busTankCapacity);

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
                            try
                            {
                                car.Refuel(value);
                            }
                            catch (ArgumentException argumentException)
                            {
                                Console.WriteLine(argumentException.Message);
                            }
                            break;
                        case "DriveEmpty":
                            ((Bus)car).SwitchOffAirConditioner();
                            Console.WriteLine(car.Drive(value));
                            ((Bus)car).SwitchOnAirConditioner();
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
                            try
                            {
                                truck.Refuel(value);
                            }
                            catch (ArgumentException argumentException)
                            {
                                Console.WriteLine(argumentException.Message);
                            }
                            break;
                        case "DriveEmpty":
                            ((Bus)truck).SwitchOffAirConditioner();
                            Console.WriteLine(truck.Drive(value));
                            ((Bus)truck).SwitchOnAirConditioner();
                            break;
                    }
                    break;
                case nameof(Bus):
                    switch (command)
                    {
                        case "Drive":
                            Console.WriteLine(bus.Drive(value));
                            break;
                        case "Refuel":
                            try
                            {
                                bus.Refuel(value);
                            }
                            catch (ArgumentException argumentException)
                            {
                                Console.WriteLine(argumentException.Message);
                            }
                            break;
                        case "DriveEmpty":
                            ((Bus)bus).SwitchOffAirConditioner();
                            Console.WriteLine(bus.Drive(value));
                            ((Bus)bus).SwitchOnAirConditioner();
                            break;
                    }
                    break;
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }
}

