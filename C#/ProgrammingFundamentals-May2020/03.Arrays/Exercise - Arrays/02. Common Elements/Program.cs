using System;
using System.Linq;

namespace _02._Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstArr = Console.ReadLine()
                .Split(' ')
                .ToArray();

            string[] secondArr = Console.ReadLine()
                .Split(' ')
                .ToArray();

            int shorterLength = Math.Min(firstArr.Length, secondArr.Length);

            for (int i = 0; i < shorterLength; i++)
            {
                if (firstArr.Contains(secondArr[i]))
                {
                    Console.Write(secondArr[i] + ' ');
                }
            }

        }
    }
}
