using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bombs
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(ReadInput());
            Stack<int> bombCasings = new Stack<int>(ReadInput());
            Dictionary<string, int> bombs = new Dictionary<string, int>()
            {
                {"Datura Bombs",0},
                {"Cherry Bombs",0},
                {"Smoke Decoy Bombs",0}
            };
            bool hasFilledThePouch = false;
            Processing(bombEffects, bombCasings, bombs, ref hasFilledThePouch);
            PrintOutput(bombEffects, bombCasings, bombs, hasFilledThePouch);
        }

        private static void PrintOutput(Queue<int> bombEffects, Stack<int> bombCasings, Dictionary<string, int> bombs, bool hasFilledThePouch)
        {
            if (hasFilledThePouch)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in bombs.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }

        private static void Processing(Queue<int> bombEffects, Stack<int> bombCasings, Dictionary<string, int> bombs, ref bool hasFilledThePouch)
        {
            while (bombEffects.Count > 0 && bombCasings.Count > 0)
            {
                if (bombs["Datura Bombs"] >= 3 && bombs["Cherry Bombs"] >= 3 && bombs["Smoke Decoy Bombs"] >= 3)
                {
                    hasFilledThePouch = true;
                    break;
                }

                int valuesSum = bombEffects.Peek() + bombCasings.Peek();
                if (valuesSum == 40 || valuesSum == 60 || valuesSum == 120)
                {
                    if (valuesSum == 40)
                    {
                        bombs["Datura Bombs"]++;
                    }
                    else if (valuesSum == 60)
                    {
                        bombs["Cherry Bombs"]++;
                    }
                    else if (valuesSum == 120)
                    {
                        bombs["Smoke Decoy Bombs"]++;
                    }
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else
                {
                    bombCasings.Push(bombCasings.Pop() - 5);
                }
            }
        }

        static int[] ReadInput() => Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();
    }
}
