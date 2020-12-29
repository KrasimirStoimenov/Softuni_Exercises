using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace _02._Book_Worm
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var sb = new StringBuilder(input);

            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int[] playerPosition = new int[2];
            ReadCharMatrix(matrix, playerPosition);
            ReadingCommands(matrix, playerPosition, sb);
            PrintOutput(matrix, sb);
        }

        private static void PrintOutput(char[,] matrix, StringBuilder sb)
        {
            Console.WriteLine(sb.ToString());

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static void ReadingCommands(char[,] matrix, int[] playerPosition, StringBuilder sb)
        {
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                int row = playerPosition[0];
                int col = playerPosition[1];
                matrix[row, col] = '-';
                switch (command)
                {
                    case "up":
                        if (row == 0)
                        {
                            sb.Remove(sb.Length - 1, 1);
                            matrix[row, col] = 'P';

                            continue;
                        }
                        row--;
                        break;
                    case "down":
                        if (row == matrix.GetLength(0) - 1)
                        {
                            sb.Remove(sb.Length - 1, 1);
                            matrix[row, col] = 'P';

                            continue;
                        }
                        row++;
                        break;
                    case "left":
                        if (col == 0)
                        {
                            sb.Remove(sb.Length - 1, 1);
                            matrix[row, col] = 'P';

                            continue;
                        }
                        col--;
                        break;
                    case "right":
                        if (col == matrix.GetLength(1) - 1)
                        {
                            sb.Remove(sb.Length - 1, 1);
                            matrix[row, col] = 'P';

                            continue;
                        }
                        col++;
                        break;
                }

                if (matrix[row, col] != '-')
                {
                    sb.Append(matrix[row, col]);
                }
                matrix[row, col] = 'P';
                playerPosition[0] = row;
                playerPosition[1] = col;
            }
        }

        private static void ReadCharMatrix(char[,] matrix, int[] playerPosition)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowArgs = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currentChar = rowArgs[col];
                    if (currentChar == 'P')
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
