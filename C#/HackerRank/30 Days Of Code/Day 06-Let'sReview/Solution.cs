using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string word = Console.ReadLine();
            string evenIndexesLetters = string.Empty;
            string oddIndexesLetters = string.Empty;

            for (int j = 0; j < word.Length; j++)
            {
                if (j % 2 == 0)
                {
                    evenIndexesLetters += word[j];
                }
                else
                {
                    oddIndexesLetters += word[j];
                }
            }

            Console.WriteLine($"{evenIndexesLetters} {oddIndexesLetters}");
        }
    }
}