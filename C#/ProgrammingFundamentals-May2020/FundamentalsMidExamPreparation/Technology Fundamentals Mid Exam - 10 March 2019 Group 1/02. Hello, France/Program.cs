using System;
using System.Linq;
using System.Collections.Generic;
namespace _02._Hello__France
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split('|')
                .ToList();
            double budget = double.Parse(Console.ReadLine());
            double maxPriceForClothes = 50.00;
            double maxPriceForShoes = 35.00;
            double maxPriceForAccessories = 20.50;

            var myItemsPrice = new List<double>();

            for (int i = 0; i < items.Count; i++)
            {
                List<string> splitted = items[i].Split("->").ToList();
                double price = double.Parse(splitted[1]);
                switch (splitted[0])
                {
                    case "Clothes":
                        if (price > maxPriceForClothes)
                        {
                            continue;
                        }
                        break;
                    case "Shoes":
                        if (price > maxPriceForShoes)
                        {
                            continue;
                        }
                        break;
                    case "Accessories":
                        if (price > maxPriceForAccessories)
                        {
                            continue;
                        }
                        break;
                }

                if (budget >= price)
                {
                    budget -= price;
                    myItemsPrice.Add(price);
                }
            }
            var myItemsNewPrice = new List<double>();
            for (int i = 0; i < myItemsPrice.Count; i++)
            {
                double price = myItemsPrice[i];
                price *= 1.40;
                myItemsNewPrice.Add(price);
            }

            foreach (var element in myItemsNewPrice)
            {
                Console.Write($"{element:F2} ");
            }
            Console.WriteLine();

            Console.WriteLine($"Profit: {myItemsNewPrice.Sum()- myItemsPrice.Sum():F2}");

            double newBudget = myItemsNewPrice.Sum() + budget;

            if (newBudget >= 150)
            {
                Console.WriteLine("Hello, France!");
            }
            else
            {
                Console.WriteLine("Time to go.");
            }

        }
    }
}