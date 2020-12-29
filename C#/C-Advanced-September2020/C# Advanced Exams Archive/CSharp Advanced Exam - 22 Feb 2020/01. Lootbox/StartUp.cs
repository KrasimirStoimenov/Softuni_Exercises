using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class StartUp
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                Queue<int> firstBox = new Queue<int>(ReadIntInput());
                Stack<int> secondBox = new Stack<int>(ReadIntInput());
                int collectionValue = 0;
                Processing(firstBox, secondBox, ref collectionValue);
                PrintOutput(firstBox, secondBox, collectionValue);
            }

            private static void PrintOutput(Queue<int> firstBox, Stack<int> secondBox, int collectionValue)
            {
                if (firstBox.Count == 0)
                {
                    Console.WriteLine("First lootbox is empty");
                }
                else
                {
                    Console.WriteLine("Second lootbox is empty");
                }

                if (collectionValue > 100)
                {
                    Console.WriteLine($"Your loot was epic! Value: {collectionValue}");
                }
                else
                {
                    Console.WriteLine($"Your loot was poor... Value: {collectionValue}");
                }
            }

            private static void Processing(Queue<int> firstBox, Stack<int> secondBox, ref int collectionValue)
            {
                while (firstBox.Count > 0 && secondBox.Count > 0)
                {
                    int summedValue = firstBox.Peek() + secondBox.Peek();
                    if (summedValue % 2 == 0)
                    {
                        collectionValue += summedValue;
                        secondBox.Pop();
                        firstBox.Dequeue();
                    }
                    else
                    {
                        firstBox.Enqueue(secondBox.Pop());
                    }
                }
            }

            static int[] ReadIntInput() => Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
        }
    }
}
