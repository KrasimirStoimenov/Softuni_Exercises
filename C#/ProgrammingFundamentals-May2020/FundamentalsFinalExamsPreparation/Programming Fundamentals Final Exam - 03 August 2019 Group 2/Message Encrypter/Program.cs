using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Message_Encrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                string pattern = @"([@|*])(?<tag>[A-Z][a-z]{2,})\1: \[(?<group1>[A-Z]|[a-z])]\|\[(?<group2>[A-Z]|[a-z])]\|\[(?<group3>[A-Z]|[a-z])]\|$";
                Match messageMatch = Regex.Match(input, pattern);
                if (messageMatch.Success)
                {
                    string tag = messageMatch.Groups["tag"].Value;
                    char firstChar = char.Parse(messageMatch.Groups["group1"].Value);
                    char secondChar = char.Parse(messageMatch.Groups["group2"].Value);
                    char thirdChar = char.Parse(messageMatch.Groups["group3"].Value);

                    Console.WriteLine($"{tag}: {(int)firstChar} {(int)secondChar} {(int)thirdChar}");

                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
