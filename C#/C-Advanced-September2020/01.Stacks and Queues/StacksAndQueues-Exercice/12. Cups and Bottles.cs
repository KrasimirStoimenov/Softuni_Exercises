using System;
using System.Linq;
using System.Collections.Generic;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = ReadIntArray();
            Queue<int> cupsQueue = new Queue<int>(cups);
            int[] bottles = ReadIntArray();
            Stack<int> bottlesStack = new Stack<int>(bottles);
            int wastedWater = 0;
            while (cupsQueue.Any() && bottlesStack.Any())
            {
                int currentCup = cupsQueue.Dequeue();
                while (currentCup > 0)
                {
                    int currentBottle = bottlesStack.Pop();
                    if (currentBottle >= currentCup)
                    {
                        wastedWater += currentBottle - currentCup;
                    }
                    currentCup -= currentBottle;
                }
            }
            Console.WriteLine(bottlesStack.Count > 0 ? $"Bottles: {string.Join(" ", bottlesStack)}" : $"Cups: {string.Join(" ", cupsQueue)}");
            Console.WriteLine($"Wasted litters of water: {wastedWater}");

        }
        static int[] ReadIntArray() => Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
    }
}
