using System;
using System.Collections.Generic;

namespace _06._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();

            string customer;
            while ((customer = Console.ReadLine()) != "End")
            {
                if (customer == "Paid")
                {
                    while (customers.Count > 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                    }
                }
                else
                {
                    customers.Enqueue(customer);
                }
            }

            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
