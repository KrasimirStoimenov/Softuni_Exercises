using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _04._Star_Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> typePlanets = new Dictionary<string, List<string>>()
            {
                ["A"] = new List<string>(),
                ["D"] = new List<string>()
            };

            int messagesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < messagesCount; i++)
            {
                string currentMessage = Console.ReadLine();
                string starPattern = @"[STARstar]";

                MatchCollection starCountCollection = Regex.Matches(currentMessage, starPattern);
                int starCount = starCountCollection.Count;

                string decryptedMessage = DecryptMessage(currentMessage, starCount);
                Proccessing(decryptedMessage, typePlanets);
            }

            PrintOutput(typePlanets);
        }

        static void PrintOutput(Dictionary<string, List<string>> typePlanets)
        {
            foreach (var planet in typePlanets)
            {
                if (planet.Key == "A")
                {
                    Console.WriteLine($"Attacked planets: {planet.Value.Count}");
                    foreach (var name in planet.Value.OrderBy(n => n))
                    {
                        Console.WriteLine($"-> {name}");
                    }
                }
                else if (planet.Key == "D")
                {
                    Console.WriteLine($"Destroyed planets: {planet.Value.Count}");
                    foreach (var name in planet.Value.OrderBy(n => n))
                    {
                        Console.WriteLine($"-> {name}");
                    }
                }
            }
        }

        static void Proccessing(string decryptedMessage, Dictionary<string, List<string>> typePlanets)
        {
            string pattern = @"@(?<planet>[A-Za-z]+)[^@\-!:>]*:(?<population>\d+)[^@\-!:>]*!(?<type>A|D)![^@\-!:>]*->(?<soldiers>\d+)";

            Match match = Regex.Match(decryptedMessage, pattern);


            if (match.Success)
            {
                string planet = match.Groups["planet"].Value;
                string population = match.Groups["population"].Value;
                string attackType = match.Groups["type"].Value;
                string soldiersCount = match.Groups["soldiers"].Value;
                if (attackType == "A")
                {
                    typePlanets["A"].Add(planet);
                }
                else
                {
                    typePlanets["D"].Add(planet);
                }
            }


        }

        static string DecryptMessage(string currentMessage, int starCount)
        {
            StringBuilder message = new StringBuilder();
            for (int i = 0; i < currentMessage.Length; i++)
            {
                message.Append((char)(currentMessage[i] - starCount));
            }

            return message.ToString();
        }
    }
}




