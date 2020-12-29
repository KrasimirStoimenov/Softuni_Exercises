using System;

namespace _02.GenericBoxofInteger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int inputArgs = int.Parse(Console.ReadLine());
                Box<int> input = new Box<int>(inputArgs);
                Console.WriteLine(input);
            }
        }
    }
}
