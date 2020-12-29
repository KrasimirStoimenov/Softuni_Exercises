using System;

namespace _07._Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());
            string result = RepeatString(word, count);

            Console.WriteLine(result);

        }
        static string RepeatString(string word, int counter)
        {
            string result = string.Empty;
            for (int i = 0; i < counter; i++)
            {
                result += word;
            }
            return result;

        }
    }
}
