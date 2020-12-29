using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Destination_Mapper
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([=\/])(?<destination>[A-Z][A-Za-z]{2,})\1";

            MatchCollection destinationMatches = Regex.Matches(input, pattern);
            List<string> destinationNames = new List<string>();
            int travelPoints = 0;

            foreach (Match match in destinationMatches)
            {
                travelPoints += match.Groups["destination"].Value.Length;
                destinationNames.Add(match.Groups["destination"].Value);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinationNames)}");
            Console.WriteLine($"Travel Points: {travelPoints}");

        }
    }
}
