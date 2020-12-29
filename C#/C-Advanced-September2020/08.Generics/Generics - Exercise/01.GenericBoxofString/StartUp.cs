using System;

namespace _01.GenericBoxofString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string inputArgs = Console.ReadLine();
                Box<string> input = new Box<string>(inputArgs);
                Console.WriteLine(input);
            }
        }
    }
}
