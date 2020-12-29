using System;
using System.Linq;
using System.Text;

namespace _05._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];
            string snake = Console.ReadLine();

            char[,] matrix = new char[rows, cols];
            FillMatrix(matrix, snake);
            PrintMatrix(matrix);
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void FillMatrix(char[,] matrix, string snake)
        {
            int snakeIndex = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int i = 0; i < matrix.GetLength(1); i++)
                    {
                        if (snakeIndex == snake.Length)
                        {
                            snakeIndex = 0;
                        }
                        matrix[row, i] = snake[snakeIndex];
                        snakeIndex++;
                    }
                }
                else
                {
                    for (int i = matrix.GetLength(1) - 1; i >= 0; i--)
                    {
                        if (snakeIndex == snake.Length)
                        {
                            snakeIndex = 0;
                        }
                        matrix[row, i] = snake[snakeIndex];
                        snakeIndex++;
                    }
                }
            }
        }
    }
}
