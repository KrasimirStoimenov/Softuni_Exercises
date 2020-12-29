using System;

namespace _03._Characters_in_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            char first = char.Parse(Console.ReadLine());
            char second = char.Parse(Console.ReadLine());

            PrintCharactersBetweenThem(first, second);
        }
        static void PrintCharactersBetweenThem(char first, char second)
        {
            int firstNum = Math.Min(first, second);
            int secondNum = Math.Max(first, second);
            for (int i = firstNum + 1; i < secondNum; i++)
            {
                char current = (char)i;
                Console.Write(current + " ");
            }
        }
    }
}
