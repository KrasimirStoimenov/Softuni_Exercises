using System;

namespace _06._Middle_Characters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string middleChar = GetMiddleCharacter(input);

            Console.WriteLine(middleChar);
        }
        static string GetMiddleCharacter(string input)
        {
            int middle = input.Length / 2;
            string result = string.Empty;

            if (input.Length % 2 == 0)
            {
                result += input[middle - 1];
                result += input[middle];
            }
            else
            {
                result += input[middle];
            }
            return result;
        }
    }
}
