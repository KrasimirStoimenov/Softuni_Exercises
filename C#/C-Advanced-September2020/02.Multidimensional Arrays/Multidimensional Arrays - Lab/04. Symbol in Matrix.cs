using System;

namespace _04._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCols = int.Parse(Console.ReadLine());

            char[,] symbolMatrix = new char[rowsCols, rowsCols];
            ReadCharMatrix(symbolMatrix);
            
            char magicSymbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < symbolMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < symbolMatrix.GetLength(1); col++)
                {
                    if (symbolMatrix[row, col] == magicSymbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
                Console.WriteLine($"{magicSymbol} does not occur in the matrix ");

        }

        static void ReadCharMatrix(char[,] symbolMatrix)
        {
            for (int row = 0; row < symbolMatrix.GetLength(0); row++)
            {
                string word = Console.ReadLine();
                for (int col = 0; col < symbolMatrix.GetLength(1); col++)
                {
                    symbolMatrix[row, col] = word[col];
                }
            }
        }
    }
}
