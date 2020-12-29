using System;

namespace _01._National_Court
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstEmployeeEficiency = int.Parse(Console.ReadLine());
            int secondEmployeeEficiency = int.Parse(Console.ReadLine());
            int thirdEmployeeEficiency = int.Parse(Console.ReadLine());

            int people = int.Parse(Console.ReadLine());

            int peopleTakenForHour = firstEmployeeEficiency + secondEmployeeEficiency + thirdEmployeeEficiency;
            int hours = 0;
            while (people > 0)
            {
                hours++;
                if (hours % 4 == 0)
                {
                    hours++;
                }
                people -= peopleTakenForHour;
            }

            Console.WriteLine($"Time needed: {hours}h.");
        }
    }
}
