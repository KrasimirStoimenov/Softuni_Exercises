using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Garden
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int n = dimensions[0];
            int m = dimensions[1];

            int[,] matrix = new int[n, m];
            List<int> plantedFlowers = new List<int>();
            Processing(matrix, plantedFlowers);
            BloomFlowers(matrix, plantedFlowers);
            PrintMatrix(matrix);

        }

        private static void BloomFlowers(int[,] matrix, List<int> plantedFlowers)
        {
            int flowersCount = plantedFlowers.Count;
            int index = 0;
            while (index != flowersCount)
            {
                int flowerRow = plantedFlowers[index];
                index++;
                int flowerCol = plantedFlowers[index];
                index++;

                matrix[flowerRow, flowerCol] = -1;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    matrix[row, flowerCol] += 1;
                }

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[flowerRow, col] += 1;
                }

            }
        }

        private static void Processing(int[,] matrix, List<int> plantedFlowers)
        {
            string command;
            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] matrixPosition = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = matrixPosition[0];
                int col = matrixPosition[1];
                if (!IndexValidator(row, matrix.GetLength(0)) || !IndexValidator(col, matrix.GetLength(1)))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }

                plantedFlowers.Add(row);
                plantedFlowers.Add(col);
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

        private static void PrintMatrix(int[,] matrix)
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
    }
}
