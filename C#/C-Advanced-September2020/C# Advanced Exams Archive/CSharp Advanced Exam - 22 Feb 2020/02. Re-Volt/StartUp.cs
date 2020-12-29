using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Re_Volt
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int commands = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int[] playerPosition = new int[2];
            ReadIntMatrix(matrix, playerPosition);
            bool hasWon = false;
            ProcessingWithCommands(matrix, playerPosition, commands, ref hasWon);
            PrintOutput(matrix, hasWon);
        }

        private static void PrintOutput(char[,] matrix, bool hasWon)
        {
            if (hasWon)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void ProcessingWithCommands(char[,] matrix, int[] playerPosition, int commands, ref bool hasWon)
        {
            int playerRow = playerPosition[0];
            int playerCol = playerPosition[1];
            for (int i = 0; i < commands; i++)
            {
                matrix[playerRow, playerCol] = '-';
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        playerRow--;
                        if (playerRow < 0)
                        {
                            playerRow = matrix.GetLength(0) - 1;
                        }
                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerRow--;
                            if (playerRow < 0)
                            {
                                playerRow = matrix.GetLength(0) - 1;
                            }
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerRow++;
                            if (playerRow > matrix.GetLength(0) - 1)
                            {
                                playerRow = 0;
                            }
                        }
                        break;
                    case "down":
                        playerRow++;
                        if (playerRow > matrix.GetLength(0) - 1)
                        {
                            playerRow = 0;
                        }

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerRow++;
                            if (playerRow > matrix.GetLength(0) - 1)
                            {
                                playerRow = 0;
                            }
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerRow--;
                            if (playerRow < 0)
                            {
                                playerRow = matrix.GetLength(0) - 1;
                            }
                        }
                        break;
                    case "left":
                        playerCol--;
                        if (playerCol < 0)
                        {
                            playerCol = matrix.GetLength(1) - 1;
                        }
                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerCol--;
                            if (playerCol < 0)
                            {
                                playerCol = matrix.GetLength(1) - 1;
                            }
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerCol++;
                            if (playerCol > matrix.GetLength(0) - 1)
                            {
                                playerCol = 0;
                            }
                        }
                        break;
                    case "right":
                        playerCol++;
                        if (playerCol > matrix.GetLength(1) - 1)
                        {
                            playerCol = 0;
                        }
                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerCol++;
                            if (playerCol > matrix.GetLength(1) - 1)
                            {
                                playerCol = 0;
                            }
                        }
                        else if (matrix[playerRow, playerCol] == 'T')
                        {                          
                            playerCol--;
                            if (playerCol < 0)
                            {
                                playerCol = matrix.GetLength(0) - 1;
                            }
                        }
                        break;
                }
                if (matrix[playerRow, playerCol] == 'F')
                {
                    matrix[playerRow, playerCol] = 'f';
                    hasWon = true;
                    break;
                }
                matrix[playerRow, playerCol] = 'f';
            }
        }

        private static void ReadIntMatrix(char[,] matrix, int[] playerPosition)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currentChar = input[col];
                    if (currentChar == 'f')
                    {
                        playerPosition[0] = row;
                        playerPosition[1] = col;
                    }
                    matrix[row, col] = currentChar;
                }
            }
        }
    }
}
