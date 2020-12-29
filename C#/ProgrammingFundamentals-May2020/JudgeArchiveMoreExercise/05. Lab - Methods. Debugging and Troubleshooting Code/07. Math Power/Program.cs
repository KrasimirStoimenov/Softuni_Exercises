using System;

namespace _07._Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            double result = GetNumberPowered(number, power);
            Console.WriteLine(result);
        }
        static double GetNumberPowered(double number, int power)
        {
            return Math.Pow(number, power);
        }
    }
}
