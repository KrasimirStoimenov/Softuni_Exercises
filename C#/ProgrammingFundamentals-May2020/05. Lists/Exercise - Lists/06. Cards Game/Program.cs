using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayerDeck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondPlayerDeck = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Proccessing(firstPlayerDeck, secondPlayerDeck);

            PrintOutput(firstPlayerDeck, secondPlayerDeck);
        }

        static void PrintOutput(List<int> firstPlayerDeck, List<int> secondPlayerDeck)
        {
            if (firstPlayerDeck.Any())
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayerDeck.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayerDeck.Sum()}");

            }
        }

        static void Proccessing(List<int> firstPlayerDeck, List<int> secondPlayerDeck)
        {
            while (true)
            {

                if (firstPlayerDeck[0] == secondPlayerDeck[0])
                {
                    firstPlayerDeck.RemoveAt(0);
                    secondPlayerDeck.RemoveAt(0);
                }
                else if (firstPlayerDeck[0] > secondPlayerDeck[0])
                {
                    firstPlayerDeck.Add(firstPlayerDeck[0]);
                    firstPlayerDeck.Add(secondPlayerDeck[0]);
                    firstPlayerDeck.RemoveAt(0);
                    secondPlayerDeck.RemoveAt(0);
                }
                else if (secondPlayerDeck[0] > firstPlayerDeck[0])
                {
                    secondPlayerDeck.Add(secondPlayerDeck[0]);
                    secondPlayerDeck.Add(firstPlayerDeck[0]);
                    firstPlayerDeck.RemoveAt(0);
                    secondPlayerDeck.RemoveAt(0);
                }
                if (firstPlayerDeck.Count == 0 || secondPlayerDeck.Count == 0)
                {
                    break;
                }

            }
        }
    }
}
