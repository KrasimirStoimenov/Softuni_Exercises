using System;
using System.Linq;

namespace _08._Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int number = GetFrequentRepeatedNumber(initialArr);
            Console.WriteLine(number);
        }
        static int GetFrequentRepeatedNumber(int[] arr)
        {
            int number = 0;
            int frequency = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                int currentFrequent = 1;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] == arr[i])
                    {
                        currentFrequent++;
                    }

                }
                if (currentFrequent > frequency)
                {
                    frequency = currentFrequent;
                    number = arr[i];
                }
            }
            return number;
        }
    }
}
