using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> dict = new SortedDictionary<char, int>();

            string input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (!dict.ContainsKey(currentChar))
                {
                    dict.Add(currentChar, 0);
                }

                dict[currentChar]++;
            }

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
            }
        }
    }
}
