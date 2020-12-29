using System;

namespace _01._Disneyland_Journey
{
    class Program
    {
        static void Main(string[] args)
        {
            double journeyCost = double.Parse(Console.ReadLine());
            int months = int.Parse(Console.ReadLine());
            double savedMoney = 0;

            for (int i = 1; i <= months; i++)
            {
                if (i % 2 != 0 && i != 1)
                {
                    savedMoney -= savedMoney * 0.16;
                }
                if (i % 4 == 0)
                {
                    savedMoney += savedMoney * 0.25;
                }
                savedMoney += journeyCost * 0.25;
            }

            if (savedMoney >= journeyCost)
            {
                Console.WriteLine($"Bravo! You can go to Disneyland and you will have {savedMoney - journeyCost:F2}lv. for souvenirs.");
            }
            else
            {
                Console.WriteLine($"Sorry. You need {journeyCost - savedMoney:F2}lv. more.");
            }
        }
    }
}
