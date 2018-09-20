using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            int[][] matrix = new int[dimensions][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split().Take(dimensions).Select(int.Parse).ToArray();
            }

            int primaryDiagonal = SumDiagonal(matrix, "primary");
            int secondaryDiagonal = SumDiagonal(matrix, "secondary");

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }

        private static int SumDiagonal(int[][] matrix, string diagonal)
        {
            int diagonalSetter = (diagonal.ToLower().Equals("secondary")) ? matrix[0].Length - 1 : 0;
            int sum = 0;

            for (int i = 0; i < matrix.Length; i++)
            {
                sum += matrix[i][Math.Abs(diagonalSetter - i)];
            }

            return sum;
        }
    }
}
