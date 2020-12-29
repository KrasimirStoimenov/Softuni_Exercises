using System;
using System.Linq;

namespace _03._Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            int[] firstArray = new int[count];

            int[] secondArray = new int[count];

            for (int i = 0; i < count; i++)
            {
                int[] currentNumbers = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                if (i % 2 == 0)
                {
                    firstArray[i] = currentNumbers[0];
                    secondArray[i] = currentNumbers[1];
                }
                else
                {
                    firstArray[i] = currentNumbers[1];
                    secondArray[i] = currentNumbers[0];
                }
            }

            Console.WriteLine(string.Join(' ', firstArray));
            Console.WriteLine(string.Join(' ', secondArray));
        }
    }
}
