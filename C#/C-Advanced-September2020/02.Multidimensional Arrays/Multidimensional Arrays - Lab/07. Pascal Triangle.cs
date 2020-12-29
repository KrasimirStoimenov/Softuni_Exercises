using System;

namespace _07._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] jaggedArray = new long[n][];
            if (n >= 1)
            {
                jaggedArray[0] = new long[] { 1 };
            }
            if (n >= 2)
            {
                jaggedArray[1] = new long[] { 1, 1 };
            }

            for (int i = 2; i < n; i++)
            {
                jaggedArray[i] = new long[i + 1];

                for (int j = 1; j < jaggedArray[i].Length-1; j++)
                {
                    jaggedArray[i][0] = 1;
                    jaggedArray[i][j] = jaggedArray[i - 1][j] + jaggedArray[i - 1][j - 1];
                    jaggedArray[i][jaggedArray[i].Length - 1] = 1;
                }
            }

            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
