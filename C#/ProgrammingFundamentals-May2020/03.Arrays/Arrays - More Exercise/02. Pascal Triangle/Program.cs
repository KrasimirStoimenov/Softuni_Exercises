using System;

namespace _02._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            if (number >= 1)
            {
                Console.WriteLine("1");
            }
            if (number >= 2)
            {
                Console.WriteLine("1 1");
            }
            int[] previousRow = new int[] { 1, 1 };
            for (int i = 3; i <= number; i++)
            {
                int[] currentRow = new int[i];

                currentRow[0] = 1;
                currentRow[currentRow.Length - 1] = 1;
                for (int j = 1; j < currentRow.Length - 1; j++)
                {
                    currentRow[j] = previousRow[j - 1] + previousRow[j];
                }

                Console.WriteLine(string.Join(' ', currentRow));

                previousRow = currentRow;

            }

        }
    }
}
