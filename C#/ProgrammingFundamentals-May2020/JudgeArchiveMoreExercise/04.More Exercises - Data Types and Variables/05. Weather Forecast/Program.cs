using System;

namespace _05._Weather_Forecast
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();

            bool isSunny = sbyte.TryParse(number, out sbyte resultSbyte);
            bool isCloudy = int.TryParse(number, out int resultInt);
            bool isWindy = long.TryParse(number, out long resultLong);
            bool isRainy = double.TryParse(number, out double resultDouble);

            if (isSunny)
            {
                Console.WriteLine("Sunny");
            }
            else if (isCloudy)
            {
                Console.WriteLine("Cloudy");
            }
            else if (isWindy)
            {
                Console.WriteLine("Windy");
            }
            else if (isRainy)
            {
                Console.WriteLine("Rainy");
            }

        }
    }
}
