using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesCount = ReadIntArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            Stack<int> clothes = new Stack<int>(clothesCount);
            int currentRackCapacity = rackCapacity;
            int rackCount = 1;
            while (clothes.Any())
            {
                int currentClothes = clothes.Pop();
                if (currentClothes > currentRackCapacity)
                {
                    rackCount++;
                    currentRackCapacity = rackCapacity;
                }
                currentRackCapacity -= currentClothes;
            }
            Console.WriteLine(rackCount);
        }
        static int[] ReadIntArray() => Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
    }
}
