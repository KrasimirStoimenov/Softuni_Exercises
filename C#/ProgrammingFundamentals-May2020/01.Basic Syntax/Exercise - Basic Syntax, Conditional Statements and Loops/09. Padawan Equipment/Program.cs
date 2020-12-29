using System;

namespace _09._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsaberprice = double.Parse(Console.ReadLine());
            double robeprice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double totalLightsaberPrice =(lightsaberprice * Math.Ceiling(studentsCount * 1.10));
            double totalRobePrice = robeprice * studentsCount;
            int freeBelt = studentsCount / 6;
            double totalBeltPrice = (beltPrice * studentsCount) - (freeBelt * beltPrice);               // every sixth belt is FREE

            double totalMoneyNeeded = totalLightsaberPrice + totalRobePrice + totalBeltPrice;

            if (budget >= totalMoneyNeeded)
            {
                Console.WriteLine($"The money is enough - it would cost {totalMoneyNeeded:F2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {totalMoneyNeeded - budget:F2}lv more.");
            }
        }
    }
}

