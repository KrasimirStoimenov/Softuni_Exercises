using System;

namespace _02._Tron_Racers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int[] firstPlayerCoordinates = new int[2];
            int[] secondPlayerCoordinates = new int[2];

            ReadMatrix(matrix, firstPlayerCoordinates, secondPlayerCoordinates);
            ReadCommands(matrix, firstPlayerCoordinates, secondPlayerCoordinates);
            PrintMatrix(matrix);
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

        private static void ReadCommands(char[,] matrix, int[] firstPlayerCoordinates, int[] secondPlayerCoordinates)
        {
            bool isAlive = true;
            while (isAlive)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstPlayerDirection = command[0];
                string secondPlayerDirection = command[1];
                MovePlayer(matrix, firstPlayerDirection, firstPlayerCoordinates, 'f', ref isAlive);
                if (!isAlive)
                {
                    break;
                }
                MovePlayer(matrix, secondPlayerDirection, secondPlayerCoordinates, 's', ref isAlive);
            }
        }

        static void MovePlayer(char[,] matrix, string direction, int[] playerCoordinates, char playerInitials, ref bool isAlive)
        {
            int row = playerCoordinates[0];
            int col = playerCoordinates[1];
            switch (direction)
            {
                case "up":
                    row -= 1;
                    if (row < 0)
                    {
                        row = matrix.GetLength(0) - 1;
                    }
                    break;
                case "down":
                    row += 1;
                    if (row > matrix.GetLength(0)-1)
                    {
                        row = 0;
                    }
                    break;
                case "left":
                    col -= 1;
                    if (col < 0)
                    {
                        col = matrix.GetLength(1)-1;
                    }
                    break;
                case "right":
                    col += 1;
                    if (col > matrix.GetLength(1)-1)
                    {
                        col = 0;
                    }
                    break;
            }
            playerCoordinates[0] = row;
            playerCoordinates[1] = col;

            if (matrix[row, col] == '*')
            {
                matrix[row, col] = playerInitials;
            }
            else
            {
                matrix[row, col] = 'x';
                isAlive = false;
            }
        }

        private static void ReadMatrix(char[,] matrix, int[] firstPlayerCoordinates, int[] secondPlayerCoordinates)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string line = Console.ReadLine();
                line.ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currentChar = line[col];
                    if (currentChar == 'f')
                    {
                        firstPlayerCoordinates[0] = row;
                        firstPlayerCoordinates[1] = col;
                    }
                    else if (currentChar == 's')
                    {
                        secondPlayerCoordinates[0] = row;
                        secondPlayerCoordinates[1] = col;
                    }

                    matrix[row, col] = currentChar;
                }
            }
        }
    }
}
