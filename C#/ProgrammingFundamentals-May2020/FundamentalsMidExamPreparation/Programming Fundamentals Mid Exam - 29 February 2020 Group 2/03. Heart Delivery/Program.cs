using System;
using System.Linq;

namespace _03._Heart_Delivery
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] houses = Console.ReadLine()
                .Split("@")
                .Select(int.Parse)
                .ToArray();

            Proccessing(houses);
            int[] cupidHouses = houses.Where(x => x != 0).ToArray();
            int[] successfullHunt = houses.Where(x => x == 0).ToArray();
            if (successfullHunt.Length == houses.Length)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {cupidHouses.Length} places.");
            }
        }

        static void Proccessing(int[] houses)
        {
            string command;

            int currentIndex = 0;
            while ((command = Console.ReadLine()) != "Love!")
            {
                string[] cmdArgs = command.Split();
                int jump = int.Parse(cmdArgs[1]);
                currentIndex += jump;
                if (currentIndex >= houses.Length)
                {
                    currentIndex = 0;
                }

                if (houses[currentIndex] == 0)
                {
                    Console.WriteLine($"Place {currentIndex} already had Valentine's day.");
                    continue;
                }
                houses[currentIndex] -= 2;
                if (houses[currentIndex] == 0)
                {
                    Console.WriteLine($"Place {currentIndex} has Valentine's day.");
                }
            }

            Console.WriteLine($"Cupid's last position was {currentIndex}.");
        }
    }
}
