using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadioactiveBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] playerPosition;
            bool[][] bunnies = InitializeMatrix(out playerPosition);
            PlayTheGame(bunnies, playerPosition);
        }

        private static void PlayTheGame(bool[][] bunnies, int[] playerPosition)
        {
            while (true)
            {
                char[] playerSpepDirections = Console.ReadLine().ToCharArray();
                bool isPlayerEscaped = false;

                foreach (var stepDirection in playerSpepDirections)
                {
                    isPlayerEscaped = IsPlayerEscaped(bunnies, playerPosition, stepDirection);
                    MultiplyBunnies(bunnies);

                    if (isPlayerEscaped)
                    {
                        PrintMatrix(bunnies);
                        Console.WriteLine($"won: {playerPosition[0]} {playerPosition[1]}");
                        return;
                    }

                    if (bunnies[playerPosition[0]][playerPosition[1]])
                    {
                        PrintMatrix(bunnies);
                        Console.WriteLine($"dead: {playerPosition[0]} {playerPosition[1]}");
                        return;
                    }
                }
            }
        }

        private static void PrintMatrix(bool[][] bunnies)
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < bunnies.Length; row++)
            {
                for (int column = 0; column < bunnies[row].Length; column++)
                {
                    sb.Append(bunnies[row][column] ? 'B' : '.');
                }

                sb.Append(Environment.NewLine);
            }

            Console.WriteLine(sb.ToString().Trim());
        }

        private static void MultiplyBunnies(bool[][] bunnies)
        {
            Stack<int[]> newBunnies = new Stack<int[]>();

            for (int row = 0; row < bunnies.Length; row++)
            {
                for (int column = 0; column < bunnies[row].Length; column++)
                {
                    if (bunnies[row][column])
                    {
                        newBunnies.Push(new int[] { row + 1, column });
                        newBunnies.Push(new int[] { row - 1, column });
                        newBunnies.Push(new int[] { row, column + 1 });
                        newBunnies.Push(new int[] { row, column - 1 });
                    }
                }
            }

            while (newBunnies.Count > 0)
            {
                int[] currentBunny = newBunnies.Pop();
                if (IsInsideTheLayer(currentBunny, bunnies))
                {
                    bunnies[currentBunny[0]][currentBunny[1]] = true;
                }
            }
        }

        private static bool IsInsideTheLayer(int[] cell, bool[][] matrix)
        {
            return cell[0] >= 0 && cell[0] < matrix.Length && cell[1] >= 0 && cell[1] < matrix[0].Length;
        }

        private static bool IsPlayerEscaped(bool[][] bunnies, int[] playerPosition, char stepDirection)
        {
            switch (stepDirection)
            {
                case 'U':
                    playerPosition[0]--;

                    if (!IsInsideTheLayer(playerPosition, bunnies))
                    {
                        playerPosition[0]++;
                        return true;
                    }

                    break;
                case 'D':
                    playerPosition[0]++;

                    if (!IsInsideTheLayer(playerPosition, bunnies))
                    {
                        playerPosition[0]--;
                        return true;
                    }

                    break;
                case 'L':
                    playerPosition[1]--;

                    if (!IsInsideTheLayer(playerPosition, bunnies))
                    {
                        playerPosition[1]++;
                        return true;
                    }

                    break;
                case 'R':
                    playerPosition[1]++;

                    if (!IsInsideTheLayer(playerPosition, bunnies))
                    {
                        playerPosition[1]--;
                        return true;
                    }

                    break;
            }

            return false;
        }

        private static bool[][] InitializeMatrix(out int[] playerPosition)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            playerPosition = new int[] { 0, 0 };
            bool[][] bunnies = new bool[dimensions[0]][];

            for (int row = 0; row < bunnies.Length; row++)
            {
                string input = Console.ReadLine();
                bunnies[row] = new bool[input.Length];

                for (int column = 0; column < bunnies[row].Length; column++)
                {
                    if (input[column] == 'B')
                    {
                        bunnies[row][column] = true;
                    }
                    else if (input[column] == 'P')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = column;
                    }
                }
            }

            return bunnies;
        }
    }
}
