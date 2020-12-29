using System;
using System.Collections.Generic;

namespace _04._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<int, decimal>> dict = new Dictionary<string, Dictionary<int, decimal>>();

            string command;
            while ((command = Console.ReadLine()) != "buy")
            {
                string[] cmdArgs = command.Split();
                string productName = cmdArgs[0];
                decimal price = decimal.Parse(cmdArgs[1]);
                int quantity = int.Parse(cmdArgs[2]);

                if (dict.ContainsKey(productName))
                {
                    if (dict[productName].ContainsKey(quantity))
                    {
                        dict[productName].Add(quantity + quantity, price);
                        dict[productName].Remove(quantity);
                        continue;
                    }
                    dict[productName].Add(quantity, price);
                }
                else
                {
                    dict[productName] = new Dictionary<int, decimal>();
                    dict[productName].Add(quantity, price);
                }
            }

            foreach (var kvp in dict)
            {
                int productQuantity = 0;
                decimal price = 0;
                foreach (var el in kvp.Value)
                {

                    productQuantity += el.Key;
                    price = el.Value;
                }
                decimal totalPrice = productQuantity * price;
                Console.WriteLine($"{kvp.Key} -> {totalPrice:F2}");
            }
        }
    }
}
