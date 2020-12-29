using System;

namespace _04._Tourist_Information
{
    class Program
    {
        static void Main(string[] args)
        {
            string unit = Console.ReadLine();
            double value = double.Parse(Console.ReadLine());
            double converted = 0;
            string metricUnit = string.Empty;

            switch (unit)
            {
                case "miles":
                    metricUnit = "kilometers";
                    converted = value * 1.60;
                    break;
                case "inches":
                    metricUnit = "centimeters";
                    converted = value * 2.54;
                    break;
                case "feet":
                    metricUnit = "centimeters";
                    converted = value * 30;
                    break;
                case "yards":
                    metricUnit = "meters";
                    converted = value * 0.91;
                    break;
                case "gallons":
                    metricUnit = "liters";
                    converted = value * 3.80;
                    break;
            }

            Console.WriteLine($"{value} {unit} = {converted:F2} {metricUnit}");
        }
    }
}
