using System;

namespace _02._Vowels_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int vowelsCount = GetVowelsCount(input);
            Console.WriteLine(vowelsCount);
        }
        static int GetVowelsCount(string input)
        {
            int vowels = 0;
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case 'A':
                    case 'a':
                    case 'o':
                    case 'O':
                    case 'I':
                    case 'i':
                    case 'u':
                    case 'U':
                    case 'e':
                    case 'E':
                        vowels++;
                        break;
                }
            }
            return vowels;
        }
    }
}
