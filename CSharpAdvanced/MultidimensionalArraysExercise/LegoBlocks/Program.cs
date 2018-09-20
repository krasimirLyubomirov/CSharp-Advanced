using System;
using System.Linq;

namespace LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] firstMatrix = ReadInput(rows);
            int[][] secondMatrix = ReadInput(rows).Select(r => r.Reverse().ToArray()).ToArray();

            PrintResult(firstMatrix, secondMatrix);
        }

        private static void PrintResult(int[][] firstMatrix, int[][] secondMatrix)
        {
            if (IsRectangularMatrix(firstMatrix, secondMatrix))
            {
                for (int row = 0; row < firstMatrix.Length; row++)
                {
                    Console.WriteLine($"[{string.Join(", ", firstMatrix[row].Concat(secondMatrix[row]))}]");
                }
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {CellsCount(firstMatrix, secondMatrix)}");
            }
        }

        private static object CellsCount(int[][] firstMatrix, int[][] secondMatrix)
        {
            int numberOfCells = 0;

            for (int row = 0; row < firstMatrix.Length; row++)
            {
                numberOfCells += firstMatrix[row].Length + secondMatrix[row].Length;
            }

            return numberOfCells;
        }

        private static bool IsRectangularMatrix(int[][] firstMatrix, int[][] secondMatrix)
        {
            for (int row = 1; row < firstMatrix.Length; row++)
            {
                if (firstMatrix[row].Length + secondMatrix[row].Length !=
                    firstMatrix[row - 1].Length + secondMatrix[row - 1].Length)
                {
                    return false;
                }
            }

            return true;
        }

        private static int[][] ReadInput(int rows)
        {
            var matrix = new int[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            return matrix;
        }
    }
}
