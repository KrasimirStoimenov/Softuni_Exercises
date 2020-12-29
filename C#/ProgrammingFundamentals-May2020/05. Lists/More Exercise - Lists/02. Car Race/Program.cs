using System;
using System.Linq;

namespace _02._Car_Race
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int counter = 1;
            double firstCarTime = GetCarsTime(array, counter);
            double secondCarTime = GetCarsTime(array);

            if (firstCarTime < secondCarTime)
            {
                Console.WriteLine($"The winner is left with total time: {firstCarTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {secondCarTime}");
            }

        }
        static double GetCarsTime(int[] arr, int counter=2)
        {
            if (counter == 1)
            {
                return GetCurrentCarTime(arr);
            }
            else
            {
                Array.Reverse(arr);
                return GetCurrentCarTime(arr);
            }

        }
        static double GetCurrentCarTime(int[] arr)
        {
            double currentCarTime = 0;
            for (int i = 0; i < arr.Length / 2; i++)
            {
                if (arr[i] == 0)
                {
                    currentCarTime *= 0.80;
                    continue;
                }
                else
                {
                    currentCarTime += arr[i];
                }
            }
            return currentCarTime;
        }
    }
}
