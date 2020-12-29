using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Message_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            int messageCount = int.Parse(Console.ReadLine());
            List<int> messageAsciiValues = new List<int>();

            for (int i = 0; i < messageCount; i++)
            {
                string input = Console.ReadLine();
                string pattern = @"!([A-Z][a-z]{2,})!:\[([A-Za-z]{8,})\]";
                Match messageMatch = Regex.Match(input, pattern);

                if (messageMatch.Success)
                {
                    foreach (char character in messageMatch.Groups[2].Value)
                    {
                        messageAsciiValues.Add(character);
                    }
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                    continue;
                }

                Console.WriteLine($"{messageMatch.Groups[1].Value}: {string.Join(" ", messageAsciiValues)}");
            }
        }
    }
}
