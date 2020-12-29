using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = ReadIntArray();
            Queue<int> queue = new Queue<int>(numbers);

            Console.WriteLine(string.Join(", ", queue));

        }
        static int[] ReadIntArray() => Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .ToArray();

    }
}
