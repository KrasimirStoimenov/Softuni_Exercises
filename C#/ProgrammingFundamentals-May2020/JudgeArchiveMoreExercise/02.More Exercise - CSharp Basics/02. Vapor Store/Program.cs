using System;

namespace _02._Vapor_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            decimal price = 0.0m;
            decimal totalSpend = 0.0m;
            bool hasEndedTheMoney = false;
            string input;
            while ((input = Console.ReadLine()) != "Game Time")
            {
                switch (input)
                {
                    case "OutFall 4":
                        price = 39.99m;
                        break;
                    case "CS: OG":
                        price = 15.99m;

                        break;
                    case "Zplinter Zell":
                        price = 19.99m;

                        break;
                    case "Honored 2":
                        price = 59.99m;

                        break;
                    case "RoverWatch":
                        price = 29.99m;

                        break;
                    case "RoverWatch Origins Edition":
                        price = 39.99m;

                        break;
                    default:
                        Console.WriteLine("Not Found");
                        continue;
                }
                if (budget < price)
                {
                    Console.WriteLine("Too Expensive");
                    continue;
                }

                budget -= price;
                totalSpend += price;

                if (budget <= 0)
                {
                    hasEndedTheMoney = true;
                    break;
                }
                Console.WriteLine($"Bought {input}");
            }
            if (hasEndedTheMoney)
            {
                Console.WriteLine("Out of money!");
            }
            else
            {
                Console.WriteLine($"Total spent: ${totalSpend:F2}. Remaining: ${budget:F2}");
            }
        }
    }
}
