using System;
using System.Text.RegularExpressions;

namespace _02.Password
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                string pattern = @"^(.+?)>([0-9]{3})\|([a-z]{3})\|([A-Z]{3})\|([^<>]{3})<\1$";
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    Console.WriteLine($"Password: {string.Concat(match.Groups[2], match.Groups[3], match.Groups[4], match.Groups[5])}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
