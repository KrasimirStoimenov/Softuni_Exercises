using System;
using System.Linq;

namespace _04._Grab_and_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = ReadIntArray();
            int indexToEnd = GetIndex(numbers);
            if (indexToEnd == -1)
            {
                Console.WriteLine("No occurrences were found!");
            }
            else
            {
                long sum = GetSumToIndexInArray(indexToEnd, numbers);
                Console.WriteLine(sum);
            }

        }

        static long GetSumToIndexInArray(int indexToEnd, int[] numbers)
        {
            long sum = 0;
            for (int i = 0; i < indexToEnd; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }

        static int GetIndex(int[] numbers)
        {
            int number = int.Parse(Console.ReadLine());
            int index = -1;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (number == numbers[i])
                {
                    index = i;
                }
            }
            return index;
        }

        static int[] ReadIntArray() => Console.ReadLine()
                                      .Split()
                                      .Select(int.Parse)
                                      .ToArray();

    }

}
