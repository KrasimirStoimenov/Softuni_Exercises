using System;
using System.Linq;

namespace _01._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = int.Parse(Console.ReadLine());

            int[,] matrix = new int[rowsAndCols, rowsAndCols];
            ReadIntMatrix(matrix);
            int primaryDiagonalSum = GetPrimaryDiagonalSum(matrix);
            int secondaryDiagonalSum = GetSecondaryDiagonalSum(matrix);

            int result = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
            Console.WriteLine(result);
        }

        static int GetSecondaryDiagonalSum(int[,] matrix)
        {
            int sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int number = matrix[i, matrix.GetLength(1) - 1 - i];
                sum += number;
            }

            return sum;
        }

        static int GetPrimaryDiagonalSum(int[,] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }

            return sum;
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
