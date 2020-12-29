using System;
using System.Linq;

namespace _04.GenericSwapMethodInteger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> input = new Box<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int inputArgs = int.Parse(Console.ReadLine());
                input.Add(inputArgs);
            }

            int[] indexArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            input.Swap(indexArgs[0], indexArgs[1]);

            Console.WriteLine(input);
        }
    }
}
