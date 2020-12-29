using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();
            Proccessing(shops);
            PrintOutput(shops);
        }

        static void PrintOutput(Dictionary<string, Dictionary<string, double>> shops)
        {
            foreach (var shop in shops.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var (product, price) in shop.Value)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }

        static void Proccessing(Dictionary<string, Dictionary<string, double>> shops)
        {
            string shop;
            while ((shop = Console.ReadLine()) != "Revision")
            {
                string[] shopInfo = shop.Split(", ").ToArray();
                string shopName = shopInfo[0];
                string product = shopInfo[1];
                double price = double.Parse(shopInfo[2]);

                if (!shops.ContainsKey(shopName))
                {
                    shops.Add(shopName, new Dictionary<string, double>());
                }

                shops[shopName].Add(product, price);


            }
        }
    }
}
