using System;
using System.Linq;

namespace _06._Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int leftSum = 0;
            bool hasFoundEqualSum = false;
            int index = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                int rightSum = 0;

                for (int right = i + 1; right < numbers.Length; right++)
                {
                    rightSum += numbers[right];
                }

                if (leftSum == rightSum)
                {
                    hasFoundEqualSum = true;
                    index = i;
                    break;
                }
                leftSum += currentNumber;
            }

            if (hasFoundEqualSum)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
