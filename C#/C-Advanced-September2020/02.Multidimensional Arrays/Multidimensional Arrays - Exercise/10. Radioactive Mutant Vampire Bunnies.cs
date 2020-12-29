using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int row = input[0];
            int col = input[1];

            char[,] matrix = new char[row, col];

            int playerRow = 0;
            int playerCol = 0;
            ReadMatrix(matrix, ref playerRow, ref playerCol);

            Proccessing(matrix, playerRow, playerCol);
        }

        static void Proccessing(char[,] matrix, int playerRow, int playerCol)
        {
            bool hasDied = false;
            bool hasWon = false;

            while (true)
            {
                if (hasDied || hasWon)
                {
                    break;
                }

                string command = Console.ReadLine();
                for (int i = 0; i < command.Length; i++)
                {
                    if (command[i] == 'L')
                    {
                        matrix[playerRow, playerCol] = '.';
                        if (playerCol == 0)
                        {
                            hasWon = true;
                        }
                        else
                        {
                            if (matrix[playerRow, playerCol - 1] == 'B')
                            {
                                hasDied = true;
                            }
                            else
                            {
                                matrix[playerRow, playerCol - 1] = 'P';
                            }
                            playerCol = playerCol - 1;

                        }
                    }
                    else if (command[i] == 'R')
                    {
                        matrix[playerRow, playerCol] = '.';
                        if (playerCol == matrix.GetLength(1) - 1)
                        {
                            hasWon = true;
                        }
                        else
                        {
                            if (matrix[playerRow, playerCol + 1] == 'B')
                            {
                                hasDied = true;
                            }
                            else
                            {
                                matrix[playerRow, playerCol + 1] = 'P';
                            }
                            playerCol = playerCol + 1;

                        }

                    }
                    else if (command[i] == 'U')
                    {
                        matrix[playerRow, playerCol] = '.';
                        if (playerRow == 0)
                        {
                            hasWon = true;
                        }
                        else
                        {
                            if (matrix[playerRow - 1, playerCol] == 'B')
                            {
                                hasDied = true;
                            }
                            else
                            {
                                matrix[playerRow - 1, playerCol] = 'P';
                            }
                            playerRow = playerRow - 1;

                        }

                    }
                    else if (command[i] == 'D')
                    {
                        matrix[playerRow, playerCol] = '.';
                        if (playerRow == matrix.GetLength(0) - 1)
                        {
                            hasWon = true;
                        }
                        else
                        {
                            if (matrix[playerRow + 1, playerCol] == 'B')
                            {
                                hasDied = true;
                            }
                            else
                            {
                                matrix[playerRow + 1, playerCol] = 'P';
                            }
                            playerRow = playerRow + 1;

                        }
                    }

                    List<int> bunniesRows = new List<int>();
                    List<int> bunniesCols = new List<int>();

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'B')
                            {
                                bunniesRows.Add(row);
                                bunniesCols.Add(col);
                            }
                        }
                    }
                    if (bunniesRows.Any())
                    {
                        for (int j = 0; j < bunniesRows.Count; j++)
                        {
                            int currentBunnyRow = bunniesRows[j];
                            int currentBunnyCol = bunniesCols[j];

                            int leftIndex = currentBunnyCol - 1;
                            int rightIndex = currentBunnyCol + 1;
                            int upperIndex = currentBunnyRow - 1;
                            int lowerIndex = currentBunnyRow + 1;
                            if (ValidateIndex(leftIndex, matrix.GetLength(1)))
                            {
                                if (matrix[currentBunnyRow, leftIndex] == 'P')
                                {
                                    hasDied = true;
                                }
                                matrix[currentBunnyRow, leftIndex] = 'B';
                            }
                            if (ValidateIndex(rightIndex, matrix.GetLength(1)))
                            {
                                if (matrix[currentBunnyRow, rightIndex] == 'P')
                                {
                                    hasDied = true;
                                }
                                matrix[currentBunnyRow, rightIndex] = 'B';
                            }
                            if (ValidateIndex(upperIndex, matrix.GetLength(0)))
                            {
                                if (matrix[upperIndex, currentBunnyCol] == 'P')
                                {
                                    hasDied = true;
                                }
                                matrix[upperIndex, currentBunnyCol] = 'B';
                            }
                            if (ValidateIndex(lowerIndex, matrix.GetLength(0)))
                            {
                                if (matrix[lowerIndex, currentBunnyCol] == 'P')
                                {
                                    hasDied = true;
                                }
                                matrix[lowerIndex, currentBunnyCol] = 'B';
                            }
                        }
                    }

                    if (hasDied || hasWon)
                    {
                        break;
                    }
                }
            }

            //PrintOutput
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
            if (hasWon)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }
            else
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }

        }

        static bool ValidateIndex(int index, int length)
        {
            if (index >= 0 && index < length)
            {
                return true;
            }

            return false;
        }

        static void ReadMatrix(char[,] matrix, ref int playerRow, ref int playerCol)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = line[col];
                    if (line[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}
