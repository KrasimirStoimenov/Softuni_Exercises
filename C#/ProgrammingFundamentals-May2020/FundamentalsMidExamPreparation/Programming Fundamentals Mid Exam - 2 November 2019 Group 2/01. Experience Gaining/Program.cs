using System;

namespace _01._Experience_Gaining
{
    class Program
    {
        static void Main(string[] args)
        {
            double experienceNeeded = double.Parse(Console.ReadLine());
            int battleCount = int.Parse(Console.ReadLine());


            double experienceEarned = 0;
            int battleCounter = 0;
            for (int i = 1; i <= battleCount; i++)
            {
                double experiencePerBattle = double.Parse(Console.ReadLine());
                if (i % 5 == 0)
                {
                    experienceEarned += experiencePerBattle * 0.90;
                }
                else if (i % 3 == 0)
                {
                    experienceEarned += experiencePerBattle * 1.15;
                }
                else
                {
                    experienceEarned += experiencePerBattle;
                }
                battleCounter++;
                if (experienceEarned >= experienceNeeded)
                {
                    break;
                }
            }
            if (experienceEarned >= experienceNeeded)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battleCounter} battles.");
            }
            else
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {experienceNeeded - experienceEarned:F2} more needed.");
            }
        }
    }
}

