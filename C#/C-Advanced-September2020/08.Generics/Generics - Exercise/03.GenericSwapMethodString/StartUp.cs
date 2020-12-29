using System;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> input = new Box<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string inputArgs = Console.ReadLine();
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
