using System;

namespace _02._Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            string firstWord = words[0];
            string secondWord = words[1];

            Console.WriteLine(GetSumCharacters(firstWord, secondWord));
        }

        static int GetSumCharacters(string firstWord, string secondWord)
        {
            int maximalLength = Math.Max(firstWord.Length, secondWord.Length);
            int sum = 0;

            for (int i = 0; i < maximalLength; i++)
            {
                if (i < firstWord.Length && i < secondWord.Length)
                {
                    sum += firstWord[i] * secondWord[i];
                }
                else if (i >= firstWord.Length)
                {
                    sum += secondWord[i];
                }
                else if (i >= secondWord.Length)
                {
                    sum += firstWord[i];
                }
            }

            return sum;
        }
    }
}
