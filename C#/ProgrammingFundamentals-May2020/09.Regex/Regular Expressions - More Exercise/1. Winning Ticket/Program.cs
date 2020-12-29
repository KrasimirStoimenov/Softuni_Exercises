using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _1._Winning_Ticket
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ")
                .ToArray();

            string pattern = @"(?<firstHalf>[@#$'^]{6,}).*(?<secondHalf>\1)";

            for (int i = 0; i < input.Length; i++)
            {
                input[i] = input[i].Trim(' ');
                if (input[i].Length < 20)
                {
                    Console.WriteLine("invalid ticket");
                    continue;
                }


                Match tickets = Regex.Match(input[i], pattern);

                if (tickets.Success)
                {
                    int money = tickets.Groups["firstHalf"].Value.Length;
                    if (money == 10)
                    {
                        Console.WriteLine($"ticket \"{input[i]}\" - {money}{tickets.Groups["firstHalf"].Value.First()} Jackpot!");
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{input[i]}\" - {money}{tickets.Groups["firstHalf"].Value.First()}");
                    }
                }
                else
                {
                    Console.WriteLine($"ticket \"{input[i]}\" - no match");
                }


            }
        }
    }
}
