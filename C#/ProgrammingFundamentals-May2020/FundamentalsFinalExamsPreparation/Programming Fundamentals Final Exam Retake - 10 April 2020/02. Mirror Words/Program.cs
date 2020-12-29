using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(#|@)(?<firstWord>[A-Za-z]{3,})\1{2}(?<secondWord>[A-Za-z]{3,})\1";

            MatchCollection pairs = Regex.Matches(input, pattern);
            List<string> mirrorWords = new List<string>();

            AddingMirrorWords(pairs, mirrorWords);
            PrintOutput(pairs, mirrorWords);

        }

        static void PrintOutput(MatchCollection pairs, List<string> mirrorWords)
        {
            if (pairs.Any())
            {
                Console.WriteLine($"{pairs.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            if (mirrorWords.Any())
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirrorWords));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
        }

        static void AddingMirrorWords(MatchCollection pairs, List<string> mirrorWords)
        {
            foreach (Match match in pairs)
            {
                string firstWord = match.Groups["firstWord"].Value;
                string secondWord = match.Groups["secondWord"].Value;

                if (areEqual(firstWord, secondWord))
                {
                    string mirrorWordsToAdd = firstWord + " <=> " + secondWord;
                    mirrorWords.Add(mirrorWordsToAdd);
                }
            }
        }

        static bool areEqual(string firstWord, string secondWord)
        {
            StringBuilder secondWordReversed = new StringBuilder();

            for (int i = secondWord.Length - 1; i >= 0; i--)
            {
                secondWordReversed.Append(secondWord[i]);
            }

            if (secondWordReversed.ToString() == firstWord)
            {
                return true;
            }

            return false;
        }
    }
}
