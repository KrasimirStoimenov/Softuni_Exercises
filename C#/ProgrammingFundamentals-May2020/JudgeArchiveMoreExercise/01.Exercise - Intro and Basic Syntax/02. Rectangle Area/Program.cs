using System;

namespace _02._Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double sum = width * length;

            Console.WriteLine($"{sum:F2}");

        }
    }
}
