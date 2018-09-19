using System;
using System.Linq;

namespace JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsAndColumns = int.Parse(Console.ReadLine());
            int[,] square = new int[rowsAndColumns, rowsAndColumns];

            for (int row = 0; row < square.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int column = 0; column < square.GetLength(1); column++)
                {
                    square[row, column] = numbers[column];
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commands = input.Split();
                string command = commands[0];

                switch (command)
                {
                    case "Add":
                        int rowAdd = int.Parse(commands[1]);
                        int colAdd = int.Parse(commands[2]);
                        int valueAdd = int.Parse(commands[3]);

                        if (rowAdd < 0 || rowAdd >= square.GetLength(0) || colAdd < 0 || colAdd >= square.GetLength(1))
                        {
                            Console.WriteLine("Invalid coordinates");
                            break;
                        }

                        square[rowAdd, colAdd] += valueAdd;
                        break;
                    case "Subtract":
                        int rowSubtract = int.Parse(commands[1]);
                        int colSubtract = int.Parse(commands[2]);
                        int valueSubtract = int.Parse(commands[3]);

                        if (rowSubtract < 0 || rowSubtract >= square.GetLength(0) || colSubtract < 0 || colSubtract >= square.GetLength(1))
                        {
                            Console.WriteLine("Invalid coordinates");
                            break;
                        }

                        square[rowSubtract, colSubtract] -= valueSubtract;
                        break;
                }
            }
            

            for (int rows = 0; rows < square.GetLength(0); rows++)
            {
                for (int columns = 0; columns < square.GetLength(1); columns++)
                {
                    Console.Write(square[rows, columns] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
