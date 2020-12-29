using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> minNumber = x=>MinNumber(numbers);
            Console.WriteLine(minNumber(numbers));
        }

        static int MinNumber(int[] numbers)
        {
            int minNumber = int.MaxValue;
            foreach (var number in numbers)
            {
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }
            return minNumber;
        }
    }
}
