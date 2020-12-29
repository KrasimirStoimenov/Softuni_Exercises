using System;
using System.Linq;

namespace _10._Pairs_by_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialArr = ReadIntArray();
            int difference = int.Parse(Console.ReadLine());

            int pairs = GetMaxPairs(initialArr, difference);
            Console.WriteLine(pairs);
        }
        static int GetMaxPairs(int[] arr, int diff)
        {
            int maxPairs = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int currentNumber = arr[i];

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] + currentNumber == diff
                        || Math.Abs(arr[j] - currentNumber) == diff)
                    {
                        maxPairs++;
                    }
                }
            }

            return maxPairs;
        }
        static int[] ReadIntArray() => Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
    }
}
