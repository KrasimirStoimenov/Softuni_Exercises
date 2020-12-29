using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(ReadIntInput());
            Queue<int> roses = new Queue<int>(ReadIntInput());

            int wreathsCrafted = 0;

            Processing(lilies, roses, ref wreathsCrafted);
            PrintOutput(wreathsCrafted);
        }

        private static void PrintOutput(int wreathsCrafted)
        {
            if (wreathsCrafted >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCrafted} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathsCrafted} wreaths more!");
            }
        }

        private static void Processing(Stack<int> lilies, Queue<int> roses, ref int wreathsCrafted)
        {
            int storedFlowers = 0;
            while (roses.Count > 0 && lilies.Count > 0)
            {
                int valuesSum = lilies.Peek() + roses.Peek();
                if (valuesSum == 15)
                {
                    wreathsCrafted++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (valuesSum > 15)
                {
                    var liliesValue = lilies.Pop() - 2;
                    lilies.Push(liliesValue);
                }
                else if (valuesSum < 15)
                {
                    storedFlowers += valuesSum;
                    lilies.Pop();
                    roses.Dequeue();
                }
            }

            int additionalWreathsFromStoredFlowers = storedFlowers / 15;
            wreathsCrafted += additionalWreathsFromStoredFlowers;
        }

        static int[] ReadIntInput() => Console.ReadLine()
            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

    }
}
