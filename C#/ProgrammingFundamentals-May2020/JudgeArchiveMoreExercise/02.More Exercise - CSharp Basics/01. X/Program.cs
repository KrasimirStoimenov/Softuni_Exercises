using System;

namespace _01._X
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int row = 0; row < number / 2; row++)
            {
                Console.WriteLine(new string(' ', row) + 'x' + new string(' ', number - row*2 - 2) + 'x');
            }

            Console.WriteLine(new string(' ', number / 2) + 'x');

            for (int row = number / 2-1; row >= 0; row--)
            {
                Console.WriteLine(new string(' ', row) + 'x' + new string(' ', number - row * 2-2) + 'x');
            }
        }
    }
}
