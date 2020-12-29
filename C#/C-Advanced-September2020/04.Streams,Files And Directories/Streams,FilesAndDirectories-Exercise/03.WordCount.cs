using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> wordsCounter = new Dictionary<string, int>();
            FillWordsToCount(wordsCounter);
            CountWords(wordsCounter);
            FillOutputFile(wordsCounter);

        }

        private static void FillOutputFile(Dictionary<string, int> wordsCounter)
        {
            using var writer = new StreamWriter("../../../actualResult.txt");

            foreach (var kvp in wordsCounter)
            {
                writer.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }

        private static void CountWords(Dictionary<string, int> wordsCounter)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                string[] lineArgs = lines[i].ToLower().Split(new char[] { ' ', ',', '.', '-' }).ToArray();
                foreach (var word in lineArgs)
                {
                    if (wordsCounter.ContainsKey(word))
                    {
                        wordsCounter[word]++;
                    }
                }
            }
        }

        private static void FillWordsToCount(Dictionary<string, int> wordsCounter)
        {
            string[] bannedWords = File.ReadAllLines("../../../words.txt");
            foreach (var word in bannedWords)
            {
                wordsCounter.Add(word, 0);
            }
        }
    }
}

