using System;
using System.Linq;

namespace _08._Upgraded_Matcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] productName = Console.ReadLine()
                .Split();

            long[] quantity = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToArray();

            decimal[] price = Console.ReadLine()
                .Split()
                .Select(decimal.Parse)
                .ToArray();

            Proccessing(productName, quantity, price);
        }

        static void Proccessing(string[] productName, long[] quantity, decimal[] price)
        {
            string product;
            while ((product = Console.ReadLine()) != "done")
            {
                string[] productArgs = product.Split();
                long quantityOrdered = long.Parse(productArgs[1]);
                int index = Array.IndexOf(productName, productArgs[0]);
                if (index > quantity.Length - 1 || quantityOrdered > quantity[index])
                {
                    Console.WriteLine($"We do not have enough {productArgs[0]}");
                    continue;
                }
                else
                {
                    Console.WriteLine($"{productName[index]} x {quantityOrdered} costs {quantityOrdered * price[index]:F2}");
                    quantity[index] -= quantityOrdered;
                }
            }
        }
    }
}
