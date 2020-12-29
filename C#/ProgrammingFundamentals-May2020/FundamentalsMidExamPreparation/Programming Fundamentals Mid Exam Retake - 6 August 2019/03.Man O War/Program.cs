using System;
using System.Linq;

namespace _03.Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] pirateShip = Console.ReadLine()
                .Split('>')
                .Select(int.Parse)
                .ToArray();
            int[] warship = Console.ReadLine()
                 .Split('>')
                   .Select(int.Parse)
                   .ToArray();

            int maximumHealth = int.Parse(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "Retire")
            {
                string[] cmdArgs = command.Split(' ');

                switch (cmdArgs[0])
                {
                    case "Fire":
                        int fireIndex = int.Parse(cmdArgs[1]);
                        int fireDamage = int.Parse(cmdArgs[2]);
                        if (fireIndex >= 0 && fireIndex < warship.Length)
                        {
                            warship[fireIndex] -= fireDamage;
                            if (warship[fireIndex] <= 0)
                            {
                                Console.WriteLine("You won! The enemy ship has sunken.");
                                return;
                            }
                        }
                        break;
                    case "Defend":
                        int defendStartIndex = int.Parse(cmdArgs[1]);
                        int defendEndIndex = int.Parse(cmdArgs[2]);
                        int defendDamage = int.Parse(cmdArgs[3]);

                        if (defendStartIndex >= 0 && defendStartIndex < pirateShip.Length
                            && defendEndIndex >= 0 && defendEndIndex < pirateShip.Length)
                        {
                            for (int i = defendStartIndex; i <= defendEndIndex; i++)
                            {
                                pirateShip[i] -= defendDamage;
                                if (pirateShip[i] <= 0)
                                {
                                    Console.WriteLine("You lost! The pirate ship has sunken.");
                                    return;
                                }
                            }
                        }
                        break;
                    case "Repair":
                        RepairPirateShip(pirateShip, maximumHealth, cmdArgs);
                        break;
                    case "Status":
                        int counterDamagedParts = 0;
                        for (int i = 0; i < pirateShip.Length; i++)
                        {
                            double lowHealth = pirateShip[i] / (double)maximumHealth * 100;
                            if (lowHealth < 20)
                            {
                                counterDamagedParts++;
                            }
                        }
                        Console.WriteLine($"{counterDamagedParts} sections need repair.");
                        break;
                }
            }

            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {warship.Sum()}");

        }

        private static void RepairPirateShip(int[] pirateShip, int maximumHealth, string[] cmdArgs)
        {
            int repairIndex = int.Parse(cmdArgs[1]);
            int health = int.Parse(cmdArgs[2]);

            if (repairIndex >= 0 && repairIndex < pirateShip.Length)
            {
                pirateShip[repairIndex] += health;
                if (pirateShip[repairIndex] > maximumHealth)
                {
                    pirateShip[repairIndex] = maximumHealth;
                }
            }
        }
    }
}
