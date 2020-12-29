using System;
using System.Linq;

namespace _01._Sum_Matrix_Elements
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
            int[,] matrix = ReadIntMatrix(rows,cols);

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(GetMatrixSum(matrix));
        }

        static int GetMatrixSum(int[,]matrix)
        {
            int sum = 0;
            foreach (var item in matrix)
            {
                sum += item;
            }
            return sum;
        }

        static int[,] ReadIntMatrix(int rows,int cols)
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
