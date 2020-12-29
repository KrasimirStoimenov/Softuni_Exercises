using System;
using System.Linq;

namespace _11._Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = ReadIntArray();
            int index = 0;
            bool hasEqualSums = CheckIfHasEqualSums(arr, ref index);

            if (hasEqualSums)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }

        }

        static bool CheckIfHasEqualSums(int[] arr, ref int index)
        {
            int leftSum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int rightSum = 0;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    rightSum += arr[j];
                }

                if (i > 0)
                {
                    leftSum += arr[i - 1];
                }
                if (leftSum == rightSum)
                {
                    index = i;
                    return true;
                }
            }
            return false;
        }

        static int[] ReadIntArray() => Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();


    }
}
