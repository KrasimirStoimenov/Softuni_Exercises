using System;
using System.Text.RegularExpressions;

namespace _02._Boss_Rush
{
    class Program
    {
        static void Main(string[] args)
        {
            int bossCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < bossCount; i++)
            {
                string boss = Console.ReadLine();
                string pattern = @"\|(?<boss>[A-Z]{4,})\|:#(?<title>[A-Za-z]+ [A-Za-z]+)#";
                Match bossMatch = Regex.Match(boss, pattern);
                if (bossMatch.Success)
                {
                    string bossName = bossMatch.Groups["boss"].Value;
                    string bossTitle = bossMatch.Groups["title"].Value;
                    Console.WriteLine($"{bossName}, The {bossTitle}");
                    Console.WriteLine($">> Strength: {bossName.Length}");
                    Console.WriteLine($">> Armour: {bossTitle.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
