using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobeClothes = new Dictionary<string, Dictionary<string, int>>();

            AddClothesInWardrobe(wardrobeClothes);
            PrintOutput(wardrobeClothes);
        }

        static void PrintOutput(Dictionary<string, Dictionary<string, int>> wardrobeClothes)
        {
            string[] clothesToWear = Console.ReadLine().Split(" ").ToArray();
            string color = clothesToWear[0];
            string cloth = clothesToWear[1];

            foreach (var kvp in wardrobeClothes)
            {
                Console.WriteLine($"{kvp.Key} clothes:");
                foreach (var (dress, count) in kvp.Value)
                {
                    if (kvp.Key == color && dress == cloth)
                    {
                        Console.WriteLine($"* {dress} - {count} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {dress} - {count}");
                }
            }

        }

        static void AddClothesInWardrobe(Dictionary<string, Dictionary<string, int>> wardrobeClothes)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] clothesArgs = Console.ReadLine().Split(" -> ").ToArray();
                string color = clothesArgs[0];
                string[] clothes = clothesArgs[1].Split(",").ToArray();

                if (!wardrobeClothes.ContainsKey(color))
                {
                    wardrobeClothes.Add(color, new Dictionary<string, int>());
                }

                foreach (var cloth in clothes)
                {
                    if (!wardrobeClothes[color].ContainsKey(cloth))
                    {
                        wardrobeClothes[color].Add(cloth, 0);
                    }

                    wardrobeClothes[color][cloth]++;
                }
            }
        }
    }
}
