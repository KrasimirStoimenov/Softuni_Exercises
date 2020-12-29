using System;
using System.Linq;

namespace _03._Maximal_Sum
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

            int[,] matrix = new int[rows, cols];
            ReadIntMatrix(matrix);
            Proccessing(matrix);
        }

        static void Proccessing(int[,] matrix)
        {
            int maxSum = int.MinValue;
            int rowIndexMaxSum = 0;
            int colIndexMaxSum = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = 0;

                    currentSum += matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2];
                    currentSum += matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2];
                    currentSum += matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        rowIndexMaxSum = row;
                        colIndexMaxSum = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{matrix[rowIndexMaxSum, colIndexMaxSum]} {matrix[rowIndexMaxSum, colIndexMaxSum + 1]} {matrix[rowIndexMaxSum, colIndexMaxSum + 2]}");
            Console.WriteLine($"{matrix[rowIndexMaxSum + 1, colIndexMaxSum]} {matrix[rowIndexMaxSum + 1, colIndexMaxSum + 1]} {matrix[rowIndexMaxSum + 1, colIndexMaxSum + 2]}");
            Console.WriteLine($"{matrix[rowIndexMaxSum + 2, colIndexMaxSum]} {matrix[rowIndexMaxSum + 2, colIndexMaxSum + 1]} {matrix[rowIndexMaxSum + 2, colIndexMaxSum + 2]}");
        }

        static void ReadIntMatrix(int[,] matrix)
        {
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
        }
    }
}
