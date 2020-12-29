using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            Proccessing(dict);
            PrintOutput(dict);
        }

        static void PrintOutput(Dictionary<string, int> dict)
        {
            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }

        static void Proccessing(Dictionary<string, int> dict)
        {
            string product;
            while ((product = Console.ReadLine()) != "stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if (dict.ContainsKey(product))
                {
                    dict[product] += quantity;
                }
                else
                {
                    dict[product] = quantity;
                }
            }
        }
    }
}
