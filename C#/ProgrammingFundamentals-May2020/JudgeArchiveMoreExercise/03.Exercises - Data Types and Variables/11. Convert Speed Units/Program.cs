using System;

namespace _11._Convert_Speed_Units
{
    class Program
    {
        static void Main(string[] args)
        {
            int distanceInMeters = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            int totalSeconds = (hours * 3600) + (minutes * 60) + seconds;

            float metersPerSecond = (float)distanceInMeters / totalSeconds;
            float kilometersPerHour = (distanceInMeters / 1000) / (float)totalSeconds * 3600;
            float milesPerHour = ((float)distanceInMeters / 1609) / (float)totalSeconds * 3600;

            Console.WriteLine($"{metersPerSecond:F6}");
            Console.WriteLine($"{kilometersPerHour:F6}");
            Console.WriteLine($"{milesPerHour:F6}");

        }
    }
}
