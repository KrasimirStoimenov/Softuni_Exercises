using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] readMales = ReadIntArray();
            Stack<int> males = new Stack<int>(readMales);
            int[] readFemales = ReadIntArray();
            Queue<int> females = new Queue<int>(readFemales);
            int matchCounter = 0;
            Processing(males, females, ref matchCounter);
            PrintOutput(males, females, matchCounter);
        }

        private static void PrintOutput(Stack<int> males, Queue<int> females, int matchCounter)
        {
            Console.WriteLine($"Matches: {matchCounter}");
            if (males.Count > 0)
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }

            if (females.Count > 0)
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }

        private static void Processing(Stack<int> males, Queue<int> females, ref int matchCounter)
        {
            while (males.Count > 0 && females.Count > 0)
            {
                var female = females.Peek();
                var male = males.Pop();

                if (female <= 0)
                {
                    females.Dequeue();
                    males.Push(male);
                    continue;
                }
                else if (male <= 0)
                {
                    continue;
                }

                if (female % 25 == 0)
                {
                    females.Dequeue();
                    females.Dequeue();
                    males.Push(male);
                    continue;
                }
                else if (male % 25 == 0)
                {
                    males.Pop();
                    continue;
                }

                if (female.Equals(male))
                {
                    females.Dequeue();
                    matchCounter++;
                }
                else
                {
                    male -= 2;
                    males.Push(male);
                    females.Dequeue();
                }
            }
        }

        private static int[] ReadIntArray() => Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}
