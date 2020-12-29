using System;
using System.Linq;

namespace _04._Triple_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            bool foundNumber = false;
            for (int i = 0; i < array.Length; i++)
            {
                int firstNumber = array[i];
                for (int b = i + 1; b < array.Length; b++)
                {
                    int secondNumber = array[b];
                    int sum = firstNumber + secondNumber;
                    if (array.Contains(sum))
                    {
                        foundNumber = true;
                        Console.WriteLine($"{firstNumber} + {secondNumber} == {firstNumber + secondNumber}");
                    }

                }
            }
            if (!foundNumber)
            {
                Console.WriteLine("No");
            }
        }
    }
}
