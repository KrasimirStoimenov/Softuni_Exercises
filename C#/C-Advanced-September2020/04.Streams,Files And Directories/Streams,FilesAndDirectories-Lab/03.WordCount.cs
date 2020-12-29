using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            using var writer = new StreamWriter("../../../Output.txt");

            foreach (var kvp in wordsCounter.OrderByDescending(x=>x.Value))
            {
                writer.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }

        private static void CountWords(Dictionary<string, int> wordsCounter)
        {
            using var reader = new StreamReader("../../../text.txt");

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] lineArgs = line.ToLower().Split(new char[] { ' ', ',', '.', '-' }).ToArray();
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
            using var wordsReader = new StreamReader("../../../words.txt");

            string[] bannedWords = wordsReader.ReadToEnd().Split(" ").ToArray();
            foreach (var word in bannedWords)
            {
                wordsCounter.Add(word, 0);
            }
        }
    }
}
