using System;
using System.Linq;

namespace PrimaryDiagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfTheSquareMatrix = int.Parse(Console.ReadLine());
            int[,] square = new int[sizeOfTheSquareMatrix, sizeOfTheSquareMatrix];

            for (int row = 0; row < square.GetLength(0); row++)
            {
                int[] rowNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int column = 0; column < square.GetLength(1); column++)
                {
                    square[row, column] = rowNumbers[column];
                }
            }

            int sum = 0;
            for (int row = 0; row < square.GetLength(0); row++)
            {
                for (int column = 0; column < square.GetLength(1); column++)
                {
                    if (row == column)
                    {
                        sum += square[row, column];
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}
