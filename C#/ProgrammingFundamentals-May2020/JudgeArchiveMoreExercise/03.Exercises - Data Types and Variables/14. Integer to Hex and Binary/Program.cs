using System;

namespace _14._Integer_to_Hex_and_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            string hex = input.ToString("X");
            string binary = Convert.ToString(input, 2);

            Console.WriteLine(hex);
            Console.WriteLine(binary);
        }
    }
}
