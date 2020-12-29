using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Emoji_Detector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> coolEmoji = new List<string>();

            ulong thresholdSum = GetCoolThreshold(input);
            int totalEmojisFound = 0;
            FindAllCoolEmojis(input, coolEmoji, thresholdSum, ref totalEmojisFound);

            Console.WriteLine($"Cool threshold: {thresholdSum}");
            Console.WriteLine($"{totalEmojisFound} emojis found in the text. The cool ones are:");
            if (coolEmoji.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, coolEmoji));
            }

        }

        static void FindAllCoolEmojis(string input, List<string> coolEmoji, ulong thresholdSum, ref int totalEmojisFound)
        {
            string emojiPattern = @"(::|\*\*)(?<emoji>[A-Z][a-z]{2,})\1";

            MatchCollection emojis = Regex.Matches(input, emojiPattern);
            totalEmojisFound = emojis.Count;
            foreach (Match emoji in emojis)
            {
                if (ValidateCoolEmoji(emoji.Groups["emoji"].Value, coolEmoji, thresholdSum))
                {
                    coolEmoji.Add(emoji.Value);
                }

            }
        }

        static bool ValidateCoolEmoji(string emoji, List<string> coolEmoji, ulong thresholdSum)
        {
            ulong emojiAsciiSum = 0;
            for (int i = 0; i < emoji.Length; i++)
            {
                emojiAsciiSum += emoji[i];
            }

            if (emojiAsciiSum > thresholdSum)               
            {
                return true;
            }

            return false;
        }

        static ulong GetCoolThreshold(string input)
        {
            ulong sum = 1;
            string numbersPattern = @"\d";
            MatchCollection numbers = Regex.Matches(input, numbersPattern);

            foreach (Match number in numbers)
            {
                sum *= ulong.Parse(number.Value);
            }
            return sum;
        }
    }
}
