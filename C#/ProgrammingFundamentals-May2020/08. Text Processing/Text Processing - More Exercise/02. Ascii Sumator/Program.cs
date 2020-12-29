using System;

namespace _02._Ascii_Sumator
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            string word = Console.ReadLine();

            int sum = 0;

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] > firstChar && word[i] < secondChar)
                {
                    sum += word[i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
