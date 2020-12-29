using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsAndCols = int.Parse(Console.ReadLine());

            int[,] matrix = ReadIntMatrix(rowsAndCols, rowsAndCols);

            int diagonalSum = GetDiagonalSum(matrix);
            Console.WriteLine(diagonalSum);
        }

        static int GetDiagonalSum(int[,] matrix)
        {
            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }
            return sum;
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
