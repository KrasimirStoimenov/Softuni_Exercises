using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] clientsCount = ReadIntArray();
            Queue<int> clients = new Queue<int>(clientsCount);
            int biggestOrder = GetBiggestOrder(clients);
            Console.WriteLine(biggestOrder);
            while (clients.Any())
            {
                int nextClient = clients.Peek();
                if (nextClient > foodQuantity)
                {
                    break;
                }

                int currentClient = clients.Dequeue();
                if (currentClient > biggestOrder)
                {
                    biggestOrder = currentClient;
                }
                foodQuantity -= currentClient;
            }

            PrintOutput(clients);   
        }


        static void PrintOutput(Queue<int> clients)
        {
            if (clients.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ",clients)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
        static int GetBiggestOrder(Queue<int> clients)
        {
            int biggestOrder = int.MinValue;
            foreach (var client in clients)
            {
                if (client > biggestOrder)
                {
                    biggestOrder = client;
                }
            }
            return biggestOrder;
        }

        static int[] ReadIntArray() => Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
    }
}
