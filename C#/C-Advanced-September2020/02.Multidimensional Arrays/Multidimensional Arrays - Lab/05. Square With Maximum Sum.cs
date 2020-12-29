using System;
using System.Linq;

namespace _05._Square_With_Maximum_Sum
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
            int maxSum = 0;
            int maxSumRow = 0;
            int maxSumCol = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int sum = matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1];
                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxSumRow = row;
                        maxSumCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxSumRow, maxSumCol]} {matrix[maxSumRow, maxSumCol + 1]}");
            Console.WriteLine($"{matrix[maxSumRow + 1, maxSumCol]} {matrix[maxSumRow + 1, maxSumCol + 1]}");
            Console.WriteLine(maxSum);
        }
        static int[,] ReadIntMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
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
