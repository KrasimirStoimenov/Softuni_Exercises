using System;

namespace _01._Counter_Strike
{
    class Program
    {
        static void Main(string[] args)
        {
            int energy = int.Parse(Console.ReadLine());
            int wonBattlesCount = 0;
            bool hasLostHisEnergy = false;
            string command;
            while ((command = Console.ReadLine()) != "End of battle")
            {
                int energyLost = int.Parse(command);
                energy -= energyLost;
                if (energy < 0)
                {
                    energy += energyLost;
                    hasLostHisEnergy = true;
                    break;
                }
                wonBattlesCount++;
                if (wonBattlesCount % 3 == 0)
                {
                    energy += wonBattlesCount;
                }

            }
            if (hasLostHisEnergy)
            {
                Console.WriteLine($"Not enough energy! Game ends with {wonBattlesCount} won battles and {energy} energy");
            }
            else
            {
                Console.WriteLine($"Won battles: {wonBattlesCount}. Energy left: {energy}");
            }
        }
    }
}
