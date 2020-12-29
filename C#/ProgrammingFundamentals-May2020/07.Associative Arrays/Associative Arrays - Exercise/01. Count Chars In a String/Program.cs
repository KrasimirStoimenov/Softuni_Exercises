using System;
using System.Collections.Generic;

namespace _01._Count_Chars_in_a_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            string word = Console.ReadLine();

            for (int i = 0; i < word.Length; i++)
            {
                char current = word[i];
                if (char.IsWhiteSpace(current))
                {
                    continue;
                }
                if (dict.ContainsKey(current))
                {
                    dict[current]++;
                }
                else
                {
                    dict[current] = 1;
                }
            }

            foreach (var el in dict)
            {
                Console.WriteLine($"{el.Key} -> {el.Value}");
            }
        }
    }
}
