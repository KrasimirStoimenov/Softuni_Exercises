using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Snake
{
    class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int[] snakePosition = new int[2];
            int firstBurrowRow = -1;
            int firstBurrowCol = -1;
            int secondBurrowRow = -1;
            int secondBurrowCol = -1;
            int foodEaten = 0;
            ReadMatrix(matrix, snakePosition, ref firstBurrowRow, ref firstBurrowCol, ref secondBurrowRow, ref secondBurrowCol);
            Processing(matrix, snakePosition, firstBurrowRow, firstBurrowCol, secondBurrowRow, secondBurrowCol, ref foodEaten);
            PrintOutput(matrix, foodEaten);
        }

        private static void PrintOutput(char[,] matrix, int foodEaten)
        {
            if (foodEaten == 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            else
            {
                Console.WriteLine("Game over!");
            }
            Console.WriteLine($"Food eaten: {foodEaten}");

            PrintMatrix(matrix);
        }

        private static void Processing(char[,] matrix, int[] snakePosition, int firstBurrowRow, int firstBurrowCol, int secondBurrowRow, int secondBurrowCol, ref int foodEaten)
        {
            int snakeRow = snakePosition[0];
            int snakeCol = snakePosition[1];
            bool gameOver = false;
            while (true)
            {
                if (foodEaten == 10)
                {
                    break;
                }
                if (gameOver)
                {
                    break;
                }
                string command = Console.ReadLine();
                matrix[snakeRow, snakeCol] = '.';
                switch (command)
                {
                    case "up":
                        snakeRow--;
                        if (!IndexValidator(snakeRow, matrix.GetLength(0)))
                        {
                            gameOver = true;
                            continue;
                        }
                        break;
                    case "down":
                        snakeRow++;
                        if (!IndexValidator(snakeRow, matrix.GetLength(0)))
                        {
                            gameOver = true;
                            continue;
                        }
                        break;
                    case "left":
                        snakeCol--;
                        if (!IndexValidator(snakeCol, matrix.GetLength(1)))
                        {
                            gameOver = true;
                            continue;
                        }
                        break;
                    case "right":
                        snakeCol++;
                        if (!IndexValidator(snakeCol, matrix.GetLength(1)))
                        {
                            gameOver = true;
                            continue;
                        }
                        break;
                }
                if (matrix[snakeRow, snakeCol] == '*')
                {
                    foodEaten++;
                }
                else if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';
                    if (snakeRow == firstBurrowRow)
                    {
                        snakeRow = secondBurrowRow;
                        snakeCol = secondBurrowCol;
                    }
                    else
                    {
                        snakeRow = firstBurrowRow;
                        snakeCol = firstBurrowCol;
                    }
                }
                matrix[snakeRow, snakeCol] = 'S';
            }
        }
        private static bool IndexValidator(int index, int length)
        {
            if (index >= 0 && index < length)
            {
                return true;
            }

            return false;
        }
        private static void PrintMatrix(char[,] matrix)
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
        private static void ReadMatrix(char[,] matrix, int[] snakePosition, ref int firstBurrowRow, ref int firstBurrowCol, ref int secondBurrowRow, ref int secondBurrowCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currentChar = input[col];

                    if (currentChar == 'S')
                    {
                        snakePosition[0] = row;
                        snakePosition[1] = col;
                    }
                    else if (currentChar == 'B')
                    {
                        if (firstBurrowCol == -1)
                        {
                            firstBurrowRow = row;
                            firstBurrowCol = col;
                        }
                        else
                        {
                            secondBurrowRow = row;
                            secondBurrowCol = col;
                        }
                    }

                    matrix[row, col] = currentChar;
                }
            }
        }
    }
}
