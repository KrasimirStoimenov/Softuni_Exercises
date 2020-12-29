using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Legendary_Farming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"fragments",0},
                {"motes",0 },
                {"shards",0 }

            };
            Dictionary<string, int> junk = new Dictionary<string, int>();

            string itemCrafted = string.Empty;

            Proccessing(dict, junk, ref itemCrafted);

            PrintOutput(dict, junk, itemCrafted);
        }

        static void PrintOutput(Dictionary<string, int> dict, Dictionary<string, int> junk, string itemCrafted)
        {
            Console.WriteLine($"{itemCrafted} obtained!");

            dict = dict.OrderByDescending(x => x.Value)
                .ThenBy(n => n.Key)
                .ToDictionary(k => k.Key, v => v.Value);
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            junk = junk.OrderBy(n => n.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in junk)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

        }

        static void Proccessing(Dictionary<string, int> dict, Dictionary<string, int> junk, ref string itemCrafted)
        {
            bool hasCraftItem = false;

            while (true)
            {
                if (hasCraftItem)
                {
                    break;
                }

                string[] cmdArgs = Console.ReadLine().Split();

                for (int i = 0; i < cmdArgs.Length; i += 2)
                {
                    int quantity = int.Parse(cmdArgs[i]);
                    string product = cmdArgs[i + 1].ToLower();

                    if (dict.ContainsKey(product))
                    {
                        dict[product] += quantity;
                        if (dict[product] >= 250)
                        {
                            hasCraftItem = true;
                            if (product == "fragments")
                            {
                                itemCrafted = "Valanyr";
                            }
                            else if (product == "shards")
                            {
                                itemCrafted = "Shadowmourne";
                            }
                            else if (product == "motes")
                            {
                                itemCrafted = "Dragonwrath";
                            }

                            dict[product] -= 250;
                            break;
                        }
                    }
                    else
                    {
                        if (junk.ContainsKey(product))
                        {
                            junk[product] += quantity;
                        }
                        else
                        {
                            junk.Add(product, quantity);
                        }
                    }
                }
            }
        }
    }
}
