using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rowsCols = int.Parse(Console.ReadLine());

            int[,] matrix = ReadIntMatrix(rowsCols, rowsCols);
            Proccessing(matrix);
            PrintMatrix(matrix);
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static void Proccessing(int[,] matrix)
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = cmdArgs[0];
                int row = int.Parse(cmdArgs[1]);
                int col = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (!IndexValidator(matrix.GetLength(0), row) || !IndexValidator(matrix.GetLength(1), col))
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }

                switch (action)
                {
                    case "Add":
                        matrix[row, col] += value;
                        break;
                    case "Subtract":
                        matrix[row, col] -= value;
                        break;
                }

            }
        }
        static bool IndexValidator(int length, int index)
        {
            if (index >= 0 && index < length)
            {
                return true;
            }
            return false;
        }

        static int[,] ReadIntMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            return matrix;
        }
    }
}
