using System;

namespace SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsAndColumns = int.Parse(Console.ReadLine());
            char[,] square = new char[rowsAndColumns, rowsAndColumns];

            for (int rows = 0; rows < square.GetLength(0); rows++)
            {
                char[] symbols = Console.ReadLine().ToCharArray();
                for (int columns = 0; columns < square.GetLength(1); columns++)
                {
                    square[rows, columns] = symbols[columns];
                }
            }

            string symbol = Console.ReadLine();

            int row = 0;
            int column = 0;
            bool hasSymbol = false;

            for (int r = 0; r < square.GetLength(0); r++)
            {
                for (int c = 0; c < square.GetLength(1); c++)
                {
                    if (square[r, c].ToString() == symbol)
                    {
                        row = r;
                        column = c;
                        hasSymbol = true;
                    }
                }
            }

            if (hasSymbol)
            {
                Console.WriteLine($"({row}, {column})");
            }
            else
            {
                Console.WriteLine($"{symbol} does not occur in the matrix");
            }
        }
    }
}
