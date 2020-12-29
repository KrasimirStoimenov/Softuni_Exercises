using System;
using System.Linq;

namespace _08._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            ReadIntMatrix(matrix);
            ManipulateMatrix(matrix);
            PrintOutput(matrix);
        }

        static void PrintOutput(int[,] matrix)
        {
            int aliveCells = 0;
            int cellsSum = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        cellsSum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {cellsSum}");
            PrintMatrix(matrix);

        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static void ManipulateMatrix(int[,] matrix)
        {
            string[] bombs = Console.ReadLine().Split(" ").ToArray();
            for (int i = 0; i < bombs.Length; i++)
            {
                string[] bombsArgs = bombs[i].Split(",").ToArray();
                int rowIndex = int.Parse(bombsArgs[0]);
                int colIndex = int.Parse(bombsArgs[1]);
                int value = matrix[rowIndex, colIndex];
                if (value > 0)
                {
                    BombsExplode(matrix, rowIndex - 1, colIndex - 1, value);
                    BombsExplode(matrix, rowIndex - 1, colIndex, value);
                    BombsExplode(matrix, rowIndex - 1, colIndex + 1, value);
                    BombsExplode(matrix, rowIndex, colIndex - 1, value);
                    BombsExplode(matrix, rowIndex, colIndex + 1, value);
                    BombsExplode(matrix, rowIndex + 1, colIndex - 1, value);
                    BombsExplode(matrix, rowIndex + 1, colIndex, value);
                    BombsExplode(matrix, rowIndex + 1, colIndex + 1, value);
                    matrix[rowIndex, colIndex] = 0;
                }
            }
        }

        static void BombsExplode(int[,] matrix, int row, int col, int value)
        {
            if (IndexValidator(row, matrix.GetLength(0)) && IndexValidator(col, matrix.GetLength(1)))
            {
                if (matrix[row, col] > 0)
                {
                    matrix[row, col] -= value;
                }
            }
        }

        static bool IndexValidator(int index, int length)
        {
            if (index >= 0 && index < length)
            {
                return true;
            }
            return false;
        }

        static void ReadIntMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
