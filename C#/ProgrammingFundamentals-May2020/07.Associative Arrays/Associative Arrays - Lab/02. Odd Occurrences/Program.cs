using System;
using System.Collections.Generic;

namespace _02._Odd_Occurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int i = 0; i < words.Length; i++)
            {
                string current = words[i].ToLower();

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
                if (el.Value % 2 != 0)
                {
                    Console.Write(el.Key + " ");
                }
            }
        }
    }
}
