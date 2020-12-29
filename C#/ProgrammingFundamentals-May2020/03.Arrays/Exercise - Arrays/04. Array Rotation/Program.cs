using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int rotationTimes = int.Parse(Console.ReadLine());
            int minimizeRotation = rotationTimes % numbers.Length;

            for (int i = 0; i < minimizeRotation; i++)
            {
                int temp = numbers[0];
                for (int j = 0; j < numbers.Length-1; j++)
                {
                    numbers[j] = numbers[j + 1];
                }
                numbers[numbers.Length - 1] = temp;
            }

            Console.WriteLine(string.Join(' ',numbers));

        }
    }
}
