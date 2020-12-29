using System;
using System.Linq;

namespace _02._Rotate_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] resultArray = new int[initialArr.Length];
            int rotation = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotation; i++)
            {
                int temp = initialArr[initialArr.Length - 1];
                for (int j = 0; j < initialArr.Length - 1; j++)
                {
                    initialArr[initialArr.Length - 1 - j] = initialArr[initialArr.Length - 2 - j];
                }
                initialArr[0] = temp;

                for (int r = 0; r < initialArr.Length; r++)
                {
                    resultArray[r] += initialArr[r];
                }
            }

            Console.WriteLine(string.Join(" ", resultArray));
        }
    }
}
