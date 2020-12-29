using System;
using System.Linq;

namespace _07._Inventory_Matcher
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
                int index = Array.IndexOf(productName, product);

                Console.WriteLine($"{productName[index]} costs: {price[index]}; Available quantity: {quantity[index]}");
            }
        }
    }
}
