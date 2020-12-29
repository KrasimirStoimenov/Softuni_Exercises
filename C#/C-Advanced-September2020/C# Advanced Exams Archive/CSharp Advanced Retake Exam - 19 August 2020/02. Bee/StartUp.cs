using System;

namespace _02._Bee
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int[] beePosition = new int[2];
            ReadCharMatrix(matrix, beePosition);

            int pollinatedFlowers = 0;
            bool gotLost = false;

            Processing(matrix, beePosition, ref pollinatedFlowers, ref gotLost);
            PrintOutput(matrix, pollinatedFlowers, gotLost);
        }

        private static void PrintOutput(char[,] matrix, int pollinatedFlowers, bool gotLost)
        {
            if (gotLost)
            {
                Console.WriteLine("The bee got lost!");
            }
            if (pollinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row,col]);
                }
                Console.WriteLine();
            }
        }

        private static void Processing(char[,] matrix, int[] beePosition, ref int pollinatedFlowers, ref bool gotLost)
        {
            int beeRow = beePosition[0];
            int beeCol = beePosition[1];

            string command;
            while ((command = Console.ReadLine()) != "End")
            {


                matrix[beeRow, beeCol] = '.';
                switch (command)
                {
                    case "up":
                        beeRow--;
                        if (!IndexValidator(beeRow, matrix.GetLength(0)))
                        {
                            gotLost = true;
                            break;
                        }
                        else if (matrix[beeRow, beeCol] == 'O')
                        {
                            matrix[beeRow, beeCol] = '.';
                            beeRow--;
                        }
                        break;
                    case "down":
                        beeRow++;
                        if (!IndexValidator(beeRow, matrix.GetLength(0)))
                        {
                            gotLost = true;
                            break;
                        }
                        else if (matrix[beeRow, beeCol] == 'O')
                        {
                            matrix[beeRow, beeCol] = '.';
                            beeRow++;
                        }
                        break;
                    case "left":
                        beeCol--;
                        if (!IndexValidator(beeCol, matrix.GetLength(1)))
                        {
                            gotLost = true;
                            break;
                        }
                        else if (matrix[beeRow, beeCol] == 'O')
                        {
                            matrix[beeRow, beeCol] = '.';
                            beeCol--;
                        }
                        break;
                    case "right":
                        beeCol++;
                        if (!IndexValidator(beeCol, matrix.GetLength(1)))
                        {
                            gotLost = true;
                            break;
                        }
                        else if (matrix[beeRow, beeCol] == 'O')
                        {
                            matrix[beeRow, beeCol] = '.';
                            beeCol++;
                        }
                        break;
                }



                if (gotLost)
                {
                    break;
                }

                if (matrix[beeRow, beeCol] == 'f')
                {
                    pollinatedFlowers++;
                }

                matrix[beeRow, beeCol] = 'B';
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

        private static void ReadCharMatrix(char[,] matrix, int[] beePosition)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char currentChar = input[col];
                    if (currentChar == 'B')
                    {
                        beePosition[0] = row;
                        beePosition[1] = col;
                    }
                    matrix[row, col] = currentChar;
                }
            }
        }
    }
}
