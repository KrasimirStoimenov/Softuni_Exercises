using System;
using System.Linq;

namespace _01._Extract_Person_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string sentence = Console.ReadLine();

                string name = GetNameAndAge('@', '|', sentence);
                string age = GetNameAndAge('#', '*', sentence);

                Console.WriteLine($"{name} is {age} years old.");
            }
        }

        static string GetNameAndAge(char firstChar, char secondChar, string sentence)
        {
            int indexStart = sentence.IndexOf(firstChar);
            int indexEnd = sentence.IndexOf(secondChar);
            int charsToTake = indexEnd - indexStart;
            string result = sentence.Substring(indexStart+1, charsToTake-1);

            return result;
        }
    }
}
