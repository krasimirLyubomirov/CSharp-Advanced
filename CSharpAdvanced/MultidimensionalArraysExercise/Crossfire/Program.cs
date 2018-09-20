using System;
using System.Collections.Generic;
using System.Linq;

namespace Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            List<List<int>> matrix = FillMatrix(rows, cols);
            string command = Console.ReadLine();

            while (command != "Nuke it from orbit")
            {
                int[] commandTokens = command.Split().Select(int.Parse).ToArray();
                int rowImpact = commandTokens[0];
                int colImpact = commandTokens[1];
                int radius = commandTokens[2];

                for (int rowIndex = rowImpact - radius; rowIndex <= rowImpact + radius; rowIndex++)
                {
                    if (IsInMatrix(rowIndex, colImpact, matrix))
                    {
                        matrix[rowIndex][colImpact] = -1;
                    }
                }

                for (int colIndex = colImpact - radius; colIndex <= colImpact + radius; colIndex++)
                {
                    if (IsInMatrix(rowImpact, colIndex, matrix))
                    {
                        matrix[rowImpact][colIndex] = -1;
                    }
                }

                FilterMatrix(matrix);
                command = Console.ReadLine();
            }

            PrintMatrix(matrix);
        }

        private static void FilterMatrix(List<List<int>> matrix)
        {
            for (int rowIndex = matrix.Count - 1; rowIndex >= 0; rowIndex--)
            {
                for (int colIndex = matrix[rowIndex].Count - 1; colIndex >= 0; colIndex--)
                {
                    if (matrix[rowIndex][colIndex] == -1)
                    {
                        matrix[rowIndex].RemoveAt(colIndex);
                    }
                }

                if (matrix[rowIndex].Count == 0)
                {
                    matrix.RemoveAt(rowIndex);
                }
            }
        }

        private static void PrintMatrix(List<List<int>> matrix)
        {
            for (int rowIndex = 0; rowIndex < matrix.Count; rowIndex++)
            {
                Console.WriteLine(String.Join(" ", matrix[rowIndex]));
            }
        }

        private static bool IsInMatrix(int currentRow, int currentCol, List<List<int>> matrix)
        {
            if (currentRow >= 0 && currentRow < matrix.Count && currentCol >= 0 && currentCol < matrix[currentRow].Count)
            {
                return true;
            }

            return false;
        }

        private static List<List<int>> FillMatrix(int rows, int cols)
        {
            List<List<int>> matrix = new List<List<int>>();
            int counter = 1;
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix.Add(new List<int>());
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    matrix[rowIndex].Add(counter);
                    counter++;
                }
            }

            return matrix;
        }
    }
}
