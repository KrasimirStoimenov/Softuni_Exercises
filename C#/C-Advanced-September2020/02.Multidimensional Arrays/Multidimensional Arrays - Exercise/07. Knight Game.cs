using System;

namespace _07._Knight_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            ReadCharMatrix(matrix);
            int knightsRemoved = GetKnightsRemoved(matrix);
            Console.WriteLine(knightsRemoved);
        }

        static int GetKnightsRemoved(char[,] matrix)
        {
            int counter = 0;
            while (true)
            {
                int maxKnightsAttacked = int.MinValue;
                int maxRow = -1;
                int maxCol = -1;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int currentKnightAttack = GetCurrentKnightAttack(matrix, row, col);

                            if (maxKnightsAttacked < currentKnightAttack)
                            {
                                maxKnightsAttacked = currentKnightAttack;
                                maxRow = row;
                                maxCol = col;
                            }
                        }
                    }
                }
                if (maxKnightsAttacked == 0)
                {
                    break;
                }

                matrix[maxRow, maxCol] = '0';
                counter++;
            }
            return counter;
        }

        static int GetCurrentKnightAttack(char[,] matrix, int row, int col)
        {
            int attackedCounter = 0;
            int indexRow = row + 2;
            int indexCol = col - 1;
            if (HasCompleteAttack(matrix, indexRow, indexCol))
            {
                attackedCounter++;
            }

            indexCol = col + 1;
            if (HasCompleteAttack(matrix, indexRow, indexCol))
            {
                attackedCounter++;
            }

            indexRow = row + 1;
            indexCol = col - 2;
            if (HasCompleteAttack(matrix, indexRow, indexCol))
            {
                attackedCounter++;
            }

            indexCol = col + 2;
            if (HasCompleteAttack(matrix, indexRow, indexCol))
            {
                attackedCounter++;
            }

            indexRow = row - 2;
            indexCol = col - 1;
            if (HasCompleteAttack(matrix, indexRow, indexCol))
            {
                attackedCounter++;
            }

            indexCol = col + 1;
            if (HasCompleteAttack(matrix, indexRow, indexCol))
            {
                attackedCounter++;
            }

            indexRow = row - 1;
            indexCol = col - 2;
            if (HasCompleteAttack(matrix, indexRow, indexCol))
            {
                attackedCounter++;
            }

            indexCol = col + 2;
            if (HasCompleteAttack(matrix, indexRow, indexCol))
            {
                attackedCounter++;
            }

            return attackedCounter;
        }

        static bool HasCompleteAttack(char[,] matrix, int row, int col)
        {
            if (IndexValidator(row, matrix.GetLength(0)) && IndexValidator(col, matrix.GetLength(1)))
            {
                if (matrix[row, col] == 'K')
                {
                    return true;
                }
            }
            return false;
        }

        static bool IndexValidator(int index, int rowColLength)
        {
            if (index >= 0 && index < rowColLength)
            {
                return true;
            }
            return false;
        }

        static void ReadCharMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
