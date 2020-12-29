using System;

namespace _01._P01
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEfficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEfficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEfficiency = int.Parse(Console.ReadLine());
            int peopleWaiting = int.Parse(Console.ReadLine());

            int totalPeopleTakenForAnHour = firstEmployeeEfficiency + secondEmployeeEfficiency + thirdEmployeeEfficiency;
            int hours = 0;
            while (peopleWaiting > 0)
            {
                hours++;
                if (hours % 4 == 0)
                {
                    hours++;
                }

                peopleWaiting -= totalPeopleTakenForAnHour;
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
