using System;
using System.Linq;

namespace _02._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsAndCols = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            char[,] matrix = new char[rows, cols];
            ReadCharMatrix(matrix);
            int equalCharMatrixCounter = SearchForEqualCharMatrix2x2(matrix);

            Console.WriteLine(equalCharMatrixCounter);
        }

        static int SearchForEqualCharMatrix2x2(char[,] matrix)
        {
            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    char currentChar = matrix[row, col];
                    if (matrix[row, col + 1] == currentChar
                        && matrix[row + 1, col] == currentChar
                        && matrix[row + 1, col + 1] == currentChar)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        static void ReadCharMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] symbols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }
        }
    }
}
