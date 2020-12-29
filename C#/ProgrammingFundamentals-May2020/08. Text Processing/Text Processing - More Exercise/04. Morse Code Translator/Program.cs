using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Morse_Code_Translator
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, char> morseCode = new Dictionary<string, char>()
            {
                ["|"] = ' ',
                [".-"] = 'A',
                ["-..."] = 'B',
                ["-.-."] = 'C',
                ["-.."] = 'D',
                ["."] = 'E',
                ["..-."] = 'F',
                ["--."] = 'G',
                ["...."] = 'H',
                [".."] = 'I',
                [".---"] = 'J',
                ["-.-"] = 'K',
                [".-.."] = 'L',
                ["--"] = 'M',
                ["-."] = 'N',
                ["---"] = 'O',
                [".--."] = 'P',
                ["--.-"] = 'Q',
                [".-."] = 'R',
                ["..."] = 'S',
                ["-"] = 'T',
                ["..-"] = 'U',
                ["...-"] = 'V',
                [".--"] = 'W',
                ["-..-"] = 'X',
                ["-.--"] = 'Y',
                ["--.."] = 'Z'
            };

            string[] morseCodeSplittedByCharacters = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            ;
            PrintOutput(morseCodeSplittedByCharacters, morseCode);
        }

        static void PrintOutput(string[] morseCodeSplittedByCharacters, Dictionary<string, char> morseCode)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < morseCodeSplittedByCharacters.Length; i++)
            {
                result.Append(morseCode[morseCodeSplittedByCharacters[i]]);
            }

            Console.WriteLine(result);
        }
    }
}
