using System;

namespace _01.Convert_Meters_To_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal meters = decimal.Parse(Console.ReadLine());
            decimal metersInKm = meters / 1000;

            Console.WriteLine($"{metersInKm:F2}");
        }
    }
}
