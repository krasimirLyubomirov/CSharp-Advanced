using System;
using System.Collections.Generic;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> parkingLot = new List<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] uniqueNumbers = input.Split(", ");
                string direction = uniqueNumbers[0];
                string carNumber = uniqueNumbers[1];

                if (direction == "IN" && parkingLot.Contains(carNumber) == false)
                {
                    parkingLot.Add(carNumber);
                }
                else if(direction == "OUT" && parkingLot.Contains(carNumber))
                {
                    parkingLot.Remove(carNumber);
                }
            }

            if (parkingLot.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var carNumber in parkingLot)
                {
                    Console.WriteLine(carNumber);
                }
            }
        }
    }
}
