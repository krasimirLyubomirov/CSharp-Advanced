using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] parkingDimensionsRolCol = InitializeParking();
            HashSet<Cell> usedCells = new HashSet<Cell>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "stop")
            {
                int carEntranceRow = int.Parse(input[0]);
                Cell carParkingAim = new Cell
                {
                    Row = int.Parse(input[1]),
                    Column = int.Parse(input[2])
                };

                if (IsCarParked(carParkingAim, usedCells, parkingDimensionsRolCol))
                {
                    Console.WriteLine(Math.Abs((carEntranceRow + 1) - (carParkingAim.Row + 1)) + carParkingAim.Column + 1);
                    usedCells.Add(carParkingAim);
                }
                else
                {
                    Console.WriteLine($"Row {carParkingAim.Row} full");
                }

                input = Console.ReadLine().Split();
            }
        }

        private static bool IsCarParked(Cell carParkingAim, HashSet<Cell> usedCells, int[] parkingDimensions)
        {
            if (usedCells.Where(c => c.Row == carParkingAim.Row && c.Column == carParkingAim.Column).FirstOrDefault() == null)
            {
                return true;
            }

            int testCol = 1;

            while (true)
            {
                int leftCol = carParkingAim.Column - testCol;
                int rightCol = carParkingAim.Column + testCol;

                if (leftCol <= 0 && rightCol >= parkingDimensions[1])
                {
                    break;
                }

                if (leftCol > 0 && usedCells.Where(c => c.Row == carParkingAim.Row && c.Column == leftCol)
                    .FirstOrDefault() == null)
                {
                    carParkingAim.Column = leftCol;
                    return true;
                }

                if (rightCol < parkingDimensions[1] &&
                    usedCells.Where(c => c.Row == carParkingAim.Row && c.Column == rightCol)
                    .FirstOrDefault() == null)
                {
                    carParkingAim.Column = rightCol;
                    return true;
                }

                testCol++;
            }

            return false;
        }

        private static int[] InitializeParking()
        {
            int[] dimmensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            return new int[] { dimmensions[0], dimmensions[1] };
        }
    }

    public class Cell
    {
        public int Row { get; set; }

        public int Column { get; set; }
    }
}
