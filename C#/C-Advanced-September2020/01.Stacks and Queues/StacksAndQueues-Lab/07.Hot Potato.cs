using System;
using System.Collections.Generic;

namespace _07._Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> players = new Queue<string>();

            AddingPlayersInGame(players);
            Proccessing(players);

            Console.WriteLine($"Last is {players.Dequeue()}");

        }

        static void Proccessing(Queue<string> players)
        {
            int tossCount = int.Parse(Console.ReadLine());
            int currentCount = 1;
            while (players.Count > 1)
            {
                if (currentCount == tossCount)
                {
                    Console.WriteLine($"Removed {players.Dequeue()}");
                    currentCount = 1;
                    continue;
                }
                string playerPassed = players.Dequeue();
                players.Enqueue(playerPassed);
                currentCount++;
            }
        }

        static void AddingPlayersInGame(Queue<string> players)
        {
            string[] participants = Console.ReadLine()
                .Split(" ");

            for (int i = 0; i < participants.Length; i++)
            {
                players.Enqueue(participants[i]);
            }
        }
    }
}
