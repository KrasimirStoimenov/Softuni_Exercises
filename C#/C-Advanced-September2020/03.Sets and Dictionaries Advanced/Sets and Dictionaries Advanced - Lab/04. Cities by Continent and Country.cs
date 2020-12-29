using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

            Proccessing(continents);
            PrintOutput(continents);
        }

        static void PrintOutput(Dictionary<string, Dictionary<string, List<string>>> continents)
        {
            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var (country, cities) in continent.Value)
                {
                    Console.WriteLine($"  {country} -> {string.Join(", ", cities)}");
                }
            }
        }

        static void Proccessing(Dictionary<string, Dictionary<string, List<string>>> continents)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] continentInfo = Console.ReadLine().Split(" ").ToArray();
                string continent = continentInfo[0];
                string country = continentInfo[1];
                string city = continentInfo[2];

                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent].Add(country, new List<string>());
                }

                continents[continent][country].Add(city);
            }
        }
    }
}
