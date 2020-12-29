using System;
using System.Linq;

namespace _01._Array_Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = ReadIntArray();

            int minNumber = GetMinNumberFromArray(numbers);
            int maxNumber = GetMaxNumberFromArray(numbers);

            double arrSum = numbers.Sum();
            double average = arrSum / numbers.Length;

            PrintOutput(minNumber, maxNumber, arrSum, average);

        }

        static void PrintOutput(int min, int max, double sum, double average)
        {
            Console.WriteLine($"Min = {min}");
            Console.WriteLine($"Max = {max}");
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine($"Average = {average}");
        }

        static int GetMaxNumberFromArray(int[] numbers)
        {
            int maxNumber = int.MinValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > maxNumber)
                {
                    maxNumber = numbers[i];
                }
            }

            return maxNumber;
        }

        static int GetMinNumberFromArray(int[] numbers)
        {
            int minNumber = int.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < minNumber)
                {
                    minNumber = numbers[i];
                }
            }
            return minNumber;
        }

        static int[] ReadIntArray() => Console.ReadLine()
                                              .Split()
                                              .Select(int.Parse)
                                              .ToArray();
    }
}
