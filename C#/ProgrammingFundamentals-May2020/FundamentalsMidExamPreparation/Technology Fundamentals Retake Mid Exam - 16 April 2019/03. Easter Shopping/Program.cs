namespace _03._Easter_Shopping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var shopList = Console.ReadLine()
                .Split(" ")
                .ToList();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] commands = Console.ReadLine()
                    .Split(" ");

                switch (commands[0])
                {
                    case "Include":
                        IncludeMethod(shopList, commands);
                        break;
                    case "Visit":
                        VisitShopMethod(shopList, commands);
                        break;
                    case "Prefer":
                        PreferShopMethod(shopList, commands);
                        break;
                    case "Place":
                        PlaceShopMethod(shopList, commands);
                        break;
                }
            }
            Console.WriteLine("Shops left:");
            Console.WriteLine(string.Join(" ", shopList));

        }

        static void PlaceShopMethod(List<string> shopList, string[] commands)
        {
            string shop = commands[1];
            int shopIndex = int.Parse(commands[2]);

            if (shopIndex >= 0 && shopIndex < shopList.Count - 1)
            {
                shopList.Insert(shopIndex + 1, shop);
            }
        }

        static void PreferShopMethod(List<string> shopList, string[] commands)
        {
            int firstShopIndex = int.Parse(commands[1]);
            int secondShopIndex = int.Parse(commands[2]);
            if (shopList.Count > firstShopIndex && shopList.Count > secondShopIndex)
            {
                string temp = shopList[firstShopIndex];
                shopList[firstShopIndex] = shopList[secondShopIndex];
                shopList[secondShopIndex] = temp;
            }
        }

        static void VisitShopMethod(List<string> shopList, string[] command)
        {
            string firstOrLast = command[1];
            int numberOfShops = int.Parse(command[2]);
            if (shopList.Count < numberOfShops)
            {
                return;
            }
            else if (firstOrLast == "first")
            {

                shopList.RemoveRange(0, numberOfShops);
            }
            else if (firstOrLast == "last")
            {
                for (int i = 0; i < numberOfShops; i++)
                {
                    shopList.RemoveAt(shopList.Count - 1);
                }
            }

        }
        static void IncludeMethod(List<string> shopList, string[] commands)
        {
            string shopToInclude = commands[1];
            shopList.Add(shopToInclude);
        }
    }
}
