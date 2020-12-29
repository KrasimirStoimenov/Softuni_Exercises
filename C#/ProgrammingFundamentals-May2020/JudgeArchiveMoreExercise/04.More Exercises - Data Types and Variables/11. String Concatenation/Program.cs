using System;

namespace _11._String_Concatenation
{
    class Program
    {
        static void Main(string[] args)
        {
            char delimeter = char.Parse(Console.ReadLine());
            string evenOrOdd = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            string result = string.Empty;
            for (int i = 1; i <= count; i++)
            {
                string currentString = Console.ReadLine();
                if (evenOrOdd == "even" && i % 2 == 0)
                {
                    result += currentString + delimeter;
                }
                else if (evenOrOdd == "odd" && i % 2 != 0)
                {
                    result += currentString + delimeter;
                }
            }
            result = result.Remove(result.Length-1);
            Console.WriteLine(result);
        }
    }
}
