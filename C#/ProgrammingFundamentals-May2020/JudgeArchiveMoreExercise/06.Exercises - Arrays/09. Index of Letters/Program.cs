using System;
using System.Linq;

namespace _09._Index_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = new char[26];
            FillAlphabetArray(alphabet);
            PrintCharacterIndex(alphabet);
        }
        static void PrintCharacterIndex(char[]arr)
        {
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (input[i] == arr[j])
                    {
                        Console.WriteLine($"{input[i]} -> {j}");
                    }
                }
            }

        }
        static void FillAlphabetArray(char[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = (char)(97 + i);
            }
        }


    }
}
