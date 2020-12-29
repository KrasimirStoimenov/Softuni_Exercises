using System;

namespace _05._Temperature_Conversion
{
    class Program
    {
        static void Main(string[] args)
        {
            double fahrenheit = double.Parse(Console.ReadLine());
            double celsius = GetCelsiusFromFahrenheit(fahrenheit);
            Console.WriteLine($"{celsius:F2}");
        }
        static double GetCelsiusFromFahrenheit(double fahr)
        {
            return (fahr - 32) * 5 / 9;
        }
    }
}
