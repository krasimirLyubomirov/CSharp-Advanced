namespace JediGalaxy
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            short[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(short.Parse).ToArray();

            int[,] matrix = InitializeMatrix(sizes);
            Ivo ivo = new Ivo();
            Evil evil = new Evil();

            string command;
            while ((command = Console.ReadLine()) != "Let the Force be with you")
            {
                UpdateCoordinates(command, ivo, evil);
                MoveEvil(evil, matrix);
                MoveIvo(ivo, matrix);
            }

            Console.WriteLine(ivo.Score);
        }

        private static void MoveIvo(Ivo ivo, int[,] matrix)
        {
            while (ivo.Row >= 0)
            {
                if (ivo.Row < matrix.GetLength(0) && ivo.Col >= 0 && ivo.Col < matrix.GetLength(1))
                {
                    ivo.CollectPoints(matrix[ivo.Row, ivo.Col]);
                }

                ivo.UpdateCoordinates(ivo.Row - 1, ivo.Col + 1);
            }
        }

        private static void MoveEvil(Evil evil, int[,] matrix)
        {
            while (evil.Row >= 0)
            {
                if (evil.Row < matrix.GetLength(0) && evil.Col >= 0 && evil.Col < matrix.GetLength(1))
                {
                    matrix[evil.Row, evil.Col] = 0;
                }

                evil.UpdateCoordinates(evil.Row - 1, evil.Col - 1);
            }
        }

        private static void UpdateCoordinates(string command, Ivo ivo, Evil evil)
        {
            int[] ivoCoordinates = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            ivo.UpdateCoordinates(ivoCoordinates[0], ivoCoordinates[1]);

            command = Console.ReadLine();

            int[] evilCoordinates = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            evil.UpdateCoordinates(evilCoordinates[0], evilCoordinates[1]);
        }

        private static int[,] InitializeMatrix(short[] sizes)
        {
            int rowsCount = sizes[0];
            int colsCount = sizes[1];
            int count = 0;
            int[,] matrix = new int[rowsCount, colsCount];

            for (short row = 0; row < rowsCount; row++)
            {
                for (short col = 0; col < colsCount; col++)
                {
                    matrix[row, col] = count++;
                }
            }

            return matrix;
        }
    }
}