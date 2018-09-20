using System;
using System.Collections.Generic;
using System.Linq;

namespace TargetPractise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            char[][] matrix = new char[dimensions[0]][].Select(r => r = new char[dimensions[1]]).ToArray();

            Queue<char> snake = new Queue<char>(Console.ReadLine().ToCharArray());

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                for (int column = matrix[row].Length - 1; column >= 0; column--)
                {
                    matrix[row][column] = snake.Dequeue();
                    snake.Enqueue(matrix[row][column]);
                }

                row--;

                if (row < 0)
                {
                    break;
                }

                for (int column = 0; column < matrix[row].Length; column++)
                {
                    matrix[row][column] = snake.Dequeue();
                    snake.Enqueue(matrix[row][column]);
                }
            }

            ShotOnSnake(matrix);
            Console.WriteLine(string.Join(Environment.NewLine, matrix.Select(r => string.Join(string.Empty, r))));
        }

        private static void ShotOnSnake(char[][] matrix)
        {
            int[] shotData = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int impactRow = shotData[0];
            int impactCol = shotData[1];
            int impactRadius = shotData[2];

            for (int row = 0; row < matrix.Length; row++)
            {
                for (int column = 0; column < matrix[row].Length; column++)
                {
                    if (IsCellShooted(row, column, impactRow, impactCol, impactRadius))
                    {
                        matrix[row][column] = ' ';
                    }
                }
            }

            for (int column = 0; column < matrix[0].Length; column++)
            {
                for (int row = matrix.Length - 1; row > 0; row--)
                {
                    if (matrix[row][column] == ' ' && matrix[row - 1][column] != ' ')
                    {
                        CellFallsDown(matrix, row, column);
                    }
                }
            }
        }

        private static void CellFallsDown(char[][] matrix, int row, int col)
        {
            while (row < matrix.Length)
            {
                if (matrix[row][col] == ' ')
                {
                    char temp = matrix[row - 1][col];
                    matrix[row - 1][col] = matrix[row][col];
                    matrix[row][col] = temp;
                    row++;
                }
                else
                {
                    return;
                }
            }
        }

        private static bool IsCellShooted(int row, int col, int impactRow, int impactCol, int impactRadius)
        {
            double distance = Math.Sqrt((row - impactRow) * (row - impactRow) + (col - impactCol) * (col - impactCol));
            return distance <= impactRadius;
        }
    }
}
