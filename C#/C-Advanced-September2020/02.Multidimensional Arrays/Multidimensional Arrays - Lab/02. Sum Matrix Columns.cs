using System;
using System.Linq;

namespace _02._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialRowsAndCols = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int rows = initialRowsAndCols[0];
            int cols = initialRowsAndCols[1];
            int[,] matrix = ReadIntMatrix(rows, cols);

            PrinOutput(matrix);
        }

        static void PrinOutput(int[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int colSum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    colSum += matrix[row, col];
                }
                Console.WriteLine(colSum);
            }
        }

        static int[,] ReadIntMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            return matrix;
        }

    }
}
