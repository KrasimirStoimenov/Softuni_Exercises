using System;

namespace _01.Distance_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsMade = int.Parse(Console.ReadLine());
            double oneStepLenghtInCentimeters = double.Parse(Console.ReadLine());
            int distanceToTravelInMeters = int.Parse(Console.ReadLine());

            double oneStepLenghtInMeters = oneStepLenghtInCentimeters / 100;
            double everyFifthStep = oneStepLenghtInMeters * 0.70;
            double traveledDistance = 0;
            for (int i = 1; i <= stepsMade; i++)
            {
                if (i % 5 == 0)
                {
                    traveledDistance += everyFifthStep;
                }
                else
                {
                    traveledDistance += oneStepLenghtInMeters;
                }
            }

            double percentage = traveledDistance / distanceToTravelInMeters * 100;

            Console.WriteLine($"You travelled {percentage:F2}% of the distance!");
        }
    }
}
