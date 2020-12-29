using System;

namespace _01._The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterForADayForOnePerson = double.Parse(Console.ReadLine());
            double foodForADayForOnePerson = double.Parse(Console.ReadLine());

            double waterNeededForAllDays = waterForADayForOnePerson * days * players;
            double foodNeededForAllDays = foodForADayForOnePerson * days * players;

            bool hasFailed = false;
            for (int i = 1; i <= days; i++)
            {
                double energyLost = double.Parse(Console.ReadLine());
                groupEnergy -= energyLost;
                if (groupEnergy <= 0)
                {
                    hasFailed = true;
                    break;
                }

                if (i % 2 == 0)
                {
                    groupEnergy *= 1.05;
                    waterNeededForAllDays *= 0.70;
                }
                if (i % 3 == 0)
                {
                    groupEnergy *= 1.10;
                    foodNeededForAllDays -= foodNeededForAllDays / players;
                }
            }

            if (hasFailed)
            {
                Console.WriteLine($"You will run out of energy. You will be left with {foodNeededForAllDays:F2} food and {waterNeededForAllDays:F2} water.");
            }
            else
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:F2} energy!");
            }
        }
    }
}
