using System;
using System.Linq;

namespace _07._Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] secondArr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int index = 0;
            bool hasDifference = false;
            for (int i = 0; i < firstArr.Length; i++)
            {
                if (firstArr[i] != secondArr[i])
                {
                    hasDifference = true;
                    index = i;
                    break;
                }
            }

            if (hasDifference)
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {index} index");
            }
            else
            {
                Console.WriteLine($"Arrays are identical. Sum: {firstArr.Sum()}");
            }
        }
    }
}
