using System;

namespace _05._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            byte quantity = byte.Parse(Console.ReadLine());
            float price = 0.00f;

            switch (product)
            {
                case "coffee":
                    price = 1.50f;
                    break;
                case "water":
                    price = 1.00f;
                    break;
                case "coke":
                    price = 1.40f;
                    break;
                case "snacks":
                    price = 2.00f;
                    break;
            }
            float result = GetTotalPrice(quantity, price);
            Console.WriteLine($"{result:F2}");
        }
        static float GetTotalPrice(byte quantity, float price)
        {
            return price * quantity;
        }
    }
}
