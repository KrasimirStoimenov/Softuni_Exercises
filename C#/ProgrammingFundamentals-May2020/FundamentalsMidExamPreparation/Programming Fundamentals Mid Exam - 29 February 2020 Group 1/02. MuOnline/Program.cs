using System;

namespace _02._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] dungeonRooms = Console.ReadLine()
                .Split("|");

            Proccessing(dungeonRooms);
        }

        static void Proccessing(string[] dungeonRooms)
        {
            int health = 100;
            int bitcoins = 0;
            bool isAlive = true;

            for (int i = 0; i < dungeonRooms.Length; i++)
            {
                string[] currentRoomArgs = dungeonRooms[i].Split();
                string tresure = currentRoomArgs[0];
                int points = int.Parse(currentRoomArgs[1]);

                ProccessingDungeonRoom(tresure, points, ref health, ref bitcoins, ref isAlive);
                if (!isAlive)
                {
                    Console.WriteLine($"Best room: {i+1}");
                    break;
                }

            }
            if (isAlive)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoins}");
                Console.WriteLine($"Health: {health}");
            }
        }
        static void ProccessingDungeonRoom(string treasure, int points, ref int health, ref int bitcoins, ref bool isAlive)
        {
            if (treasure == "potion")
            {
                if (health + points > 100)
                {
                    Console.WriteLine($"You healed for {100 - health} hp.");
                    health = 100;
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else
                {
                    health += points;
                    Console.WriteLine($"You healed for {points} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
            }
            else if (treasure == "chest")
            {
                bitcoins += points;
                Console.WriteLine($"You found {points} bitcoins.");
            }
            else
            {
                health -= points;
                if (health > 0)
                {
                    Console.WriteLine($"You slayed {treasure}.");
                }
                else
                {
                    Console.WriteLine($"You died! Killed by {treasure}.");
                    isAlive = false;
                }
            }

        }
    }
}
