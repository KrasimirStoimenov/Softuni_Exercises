using System;

namespace _08._Center_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            PrintClosestPoint(x1, y1, x2, y2);

        }
        static void PrintClosestPoint(double num1, double num2, double num3, double num4)
        {
            double firstPoint = GetPointsInCoordinates(num1, num2);
            double secondPoint = GetPointsInCoordinates(num3, num4);

            if (firstPoint <= secondPoint)
            {
                Console.WriteLine($"({num1}, {num2})");
            }
            else
            {
                Console.WriteLine($"({num3}, {num4})");
            }
        }

        static double GetPointsInCoordinates(double x, double y)
        {
            return Math.Abs(x) + Math.Abs(y);
        }
    }
}
