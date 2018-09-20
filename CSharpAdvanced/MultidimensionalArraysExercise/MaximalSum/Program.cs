using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int[][] matrix = new int[dimensions[0]][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine().Split().Take(dimensions[1]).Select(int.Parse).ToArray();
            }

            var biggestSum = int.MinValue;
            var resultStartIndex = new int[2];

            for (int row = 0; row < matrix.Length - 2; row++)
            {
                for (int column = 0; column < matrix[row].Length - 2; column++)
                {
                    var testSum = matrix[row][column] + matrix[row][column + 1] + matrix[row][column + 2] +
                        matrix[row + 1][column] + matrix[row + 1][column + 1] + matrix[row + 1][column + 2] +
                        matrix[row + 2][column] + matrix[row + 2][column + 1] + matrix[row + 2][column + 2];

                    if (testSum > biggestSum)
                    {
                        biggestSum = testSum;
                        resultStartIndex[0] = row;
                        resultStartIndex[1] = column;
                    }
                }
            }

            Console.WriteLine($"Sum = {biggestSum}");
            Console.WriteLine(string.Join(Environment.NewLine, matrix.Skip(resultStartIndex[0]).Take(3)
                .Select(row => string.Join(" ", row.Skip(resultStartIndex[1]).Take(3)))));
        }
    }
}
