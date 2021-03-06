﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> productNames = new List<string>();
            string pattern = @">>(?<product>[A-Za-z]+)<<(?<price>\d+\.?\d+)!(?<quantity>\d+)";

            decimal totalPrice = 0.0m;

            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match currentMatch = Regex.Match(input, pattern);
                if (currentMatch.Success)
                {
                    totalPrice += decimal.Parse(currentMatch.Groups["price"].Value)
                        * int.Parse(currentMatch.Groups["quantity"].Value);

                    productNames.Add(currentMatch.Groups["product"].Value);
                }
            }
            Console.WriteLine("Bought furniture:");
            foreach (var product in productNames)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine($"Total money spend: {totalPrice:f2}");
        }
    }
}
