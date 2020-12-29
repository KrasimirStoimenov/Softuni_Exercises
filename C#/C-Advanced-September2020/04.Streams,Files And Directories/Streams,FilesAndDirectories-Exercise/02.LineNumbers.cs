using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            string[] result = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                int lettersCount = GetLettersCount(lines[i]);
                int punctuationsCount = GetPunctuationCount(lines[i]);

                result[i] = $"Line {i + 1}: {lines[i]} ({lettersCount})({punctuationsCount})";
            }

            File.WriteAllLines("../../../Output.txt", result);

        }
        static int GetPunctuationCount(string line)
        {
            int punctuationCounter = 0;
            foreach (var @char in line)
            {
                if (char.IsPunctuation(@char))
                {
                    punctuationCounter++;
                }
            }
            return punctuationCounter;
        }

        static int GetLettersCount(string line)
        {
            int lettersCounter = 0;
            foreach (var @char in line)
            {
                if (char.IsLetter(@char))
                {
                    lettersCounter++;
                }
            }
            return lettersCounter;
        }
    }
}
