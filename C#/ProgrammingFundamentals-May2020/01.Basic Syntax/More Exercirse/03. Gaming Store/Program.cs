using System;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double price = 0;
            double totalSpend = 0;
            string product;
            while ((product = Console.ReadLine()) != "Game Time")
            {
                switch (product)
                {
                    case "OutFall 4":
                        price = 39.99;
                        break;
                    case "CS: OG":
                        price = 15.99;
                        break;
                    case "Zplinter Zell":
                        price = 19.99;
                        break;
                    case "Honored 2":
                        price = 59.99;
                        break;
                    case "RoverWatch":
                        price = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        price = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        continue;
                }
                if (budget >= price)
                {
                    budget -= price;
                    totalSpend += price;
                    Console.WriteLine($"Bought {product}");
                }
                else
                {
                    Console.WriteLine("Too Expensive");
                }

                if (budget <= 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }
            }

            Console.WriteLine($"Total spent: ${totalSpend:F2}. Remaining: ${budget:F2}");
        }
    }
}
