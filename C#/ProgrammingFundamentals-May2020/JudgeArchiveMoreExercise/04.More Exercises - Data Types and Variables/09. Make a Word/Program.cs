using System;

namespace _09._Make_a_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string result = string.Empty;
            for (int i = 0; i < count; i++)
            {
                char character = char.Parse(Console.ReadLine());
                result += character;
            }
            Console.WriteLine($"The word is: {result}");
        }
    }
}
