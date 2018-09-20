using System;
using System.Linq;
using System.Text;

namespace MatrixOfPalindromes
{
    class Program
    {
        public static void Main()
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            StringBuilder results = new StringBuilder();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    char borderChar = (char)('a' + row);
                    char middleChar = (char)(borderChar + col);
                    results.Append($"{borderChar}{middleChar}{borderChar} ");
                }

                if (row != rows - 1)
                {
                    results.Append(Environment.NewLine);
                }
            }

            Console.WriteLine(results.ToString());
        }
    }
}
