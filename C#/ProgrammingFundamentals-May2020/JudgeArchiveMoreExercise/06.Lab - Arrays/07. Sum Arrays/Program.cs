using System;
using System.Linq;

namespace _07._Sum_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] secondArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int counter = Math.Max(firstArray.Length, secondArray.Length);
            int[] sumArray = new int[counter];

            for (int i = 0; i < counter; i++)
            {
                sumArray[i] = firstArray[i%firstArray.Length] + secondArray[i%secondArray.Length];
            }

            Console.WriteLine(string.Join(" ", sumArray));


        }
    }
}
