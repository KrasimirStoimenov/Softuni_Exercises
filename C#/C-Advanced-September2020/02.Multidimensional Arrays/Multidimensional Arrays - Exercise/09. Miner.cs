using System;
using System.Linq;

namespace _09._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine().Split(" ").ToArray();
            char[,] matrix = new char[n, n];
            int minerStartingRowPosition = -1;
            int minerStartingColPosition = -1;
            int totalCoalInMap = 0;
            ReadCharMatrix(matrix, ref minerStartingRowPosition, ref minerStartingColPosition, ref totalCoalInMap);
            Proccessing(directions, matrix, minerStartingRowPosition, minerStartingColPosition, totalCoalInMap);
        }

        static void Proccessing(string[] directions, char[,] matrix, int minerStartingRowPosition, int minerStartingColPosition, int totalCoal)
        {
            int coalCollected = 0;
            bool gameOver = false;
            bool hasCollectedAllCoal = false;
            int row = minerStartingRowPosition;
            int col = minerStartingColPosition;

            for (int i = 0; i < directions.Length; i++)
            {
                string currentDirection = directions[i];
                matrix[row, col] = '*';
                switch (currentDirection)
                {
                    case "up":
                        if (IndexValidator(row - 1, matrix.GetLength(0)) && IndexValidator(col, matrix.GetLength(1)))
                        {
                            row = row - 1;
                            if (matrix[row, col] == 'c')
                            {
                                totalCoal--;
                                coalCollected++;
                                matrix[row, col] = '*';

                            }
                            else if (matrix[row, col] == 'e')
                            {
                                gameOver = true;
                            }
                            matrix[row, col] = 's';
                        }
                        break;
                    case "down":
                        if (IndexValidator(row + 1, matrix.GetLength(0)) && IndexValidator(col, matrix.GetLength(1)))
                        {
                            row = row + 1;
                            if (matrix[row, col] == 'c')
                            {
                                totalCoal--;
                                coalCollected++;
                                matrix[row, col] = '*';

                            }
                            else if (matrix[row, col] == 'e')
                            {
                                gameOver = true;
                            }
                            matrix[row, col] = 's';
                        }
                        break;
                    case "right":
                        if (IndexValidator(row, matrix.GetLength(0)) && IndexValidator(col + 1, matrix.GetLength(1)))
                        {
                            col = col + 1;
                            if (matrix[row, col] == 'c')
                            {
                                totalCoal--;
                                coalCollected++;
                                matrix[row, col] = '*';

                            }
                            else if (matrix[row, col] == 'e')
                            {
                                gameOver = true;
                            }
                            matrix[row, col] = 's';
                        }
                        break;
                    case "left":
                        if (IndexValidator(row, matrix.GetLength(0)) && IndexValidator(col - 1, matrix.GetLength(1)))
                        {
                            col = col - 1;
                            if (matrix[row, col] == 'c')
                            {
                                totalCoal--;
                                coalCollected++;
                                matrix[row, col] = '*';
                            }
                            else if (matrix[row, col] == 'e')
                            {
                                gameOver = true;
                            }
                            matrix[row, col] = 's';
                        }
                        break;
                }
                if (totalCoal == 0)
                {
                    hasCollectedAllCoal = true;
                    break;
                }
                if (gameOver)
                {
                    break;
                }
            }

            if (hasCollectedAllCoal)
            {
                Console.WriteLine($"You collected all coals! ({row}, {col})");
            }
            else if (gameOver)
            {
                Console.WriteLine($"Game over! ({row}, {col})");
            }
            else
            {
                Console.WriteLine($"{totalCoal} coals left. ({row}, {col})");
            }
        }
        static bool IndexValidator(int index, int rowColLength)
        {
            if (index >= 0 && index < rowColLength)
            {
                return true;
            }
            return false;
        }
        static void ReadCharMatrix(char[,] matrix, ref int minerStartingRowPosition, ref int minerStartingColPosition, ref int totalCoalInMap)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine()
                    .Split(" ")
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                    if (input[col] == 's')
                    {
                        minerStartingRowPosition = row;
                        minerStartingColPosition = col;
                    }
                    else if (input[col] == 'c')
                    {
                        totalCoalInMap++;
                    }
                }
            }
        }
    }
}
