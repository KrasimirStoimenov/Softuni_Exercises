using System;

namespace _07._Training_Hall_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal budget = decimal.Parse(Console.ReadLine());
            int productCount = int.Parse(Console.ReadLine());
            decimal sum = 0m;

            for (int i = 0; i < productCount; i++)
            {
                string productName = Console.ReadLine();
                decimal productPrice = decimal.Parse(Console.ReadLine());
                int itemCount = int.Parse(Console.ReadLine());

                if (itemCount == 1)
                {
                    Console.WriteLine($"Adding {itemCount} {productName} to cart.");
                }
                else
                {
                    Console.WriteLine($"Adding {itemCount} {productName}s to cart.");
                }

                sum += productPrice * itemCount;
            }

            Console.WriteLine($"Subtotal: ${sum:F2}");

            if (budget >= sum)
            {
                Console.WriteLine($"Money left: ${budget - sum:F2}");
            }
            else
            {
                Console.WriteLine($"Not enough. We need ${sum - budget:F2} more.");
            }


        }
    }
}
