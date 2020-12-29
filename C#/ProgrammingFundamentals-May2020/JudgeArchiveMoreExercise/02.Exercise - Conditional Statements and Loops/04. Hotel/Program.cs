using System;

namespace _04._Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studioPrice = 0;
            double doublePrice = 0;
            double suitePrice = 0;

            switch (month)
            {
                case "May":
                case "October":
                    if (nights > 7)
                    {
                        studioPrice = (50 * 0.95) * nights;
                        if (month == "October")
                        {
                            studioPrice = (50 * 0.95) * (nights - 1);
                        }
                    }
                    else
                    {
                        studioPrice = 50 * nights;
                    }
                    doublePrice = 65 * nights;
                    suitePrice = 75 * nights;
                    break;
                case "June":
                case "September":
                    if (nights > 7 && month == "September")
                    {
                        studioPrice = 60 * (nights - 1);
                    }
                    else
                    {
                        studioPrice = 60 * nights;
                    }

                    if (nights > 14)
                    {
                        doublePrice = (72 * 0.90) * nights;
                    }
                    else
                    {
                        doublePrice = 72 * nights;
                    }
                    suitePrice = 82 * nights;
                    break;
                case "July":
                case "August":
                case "December":
                    if (nights > 14)
                    {
                        suitePrice = (89 * 0.85) * nights;
                    }
                    else
                    {
                        suitePrice = 89 * nights;
                    }
                    studioPrice = 68 * nights;
                    doublePrice = 77 * nights;
                    break;
            }

            Console.WriteLine($"Studio: {studioPrice:F2} lv.");
            Console.WriteLine($"Double: {doublePrice:F2} lv.");
            Console.WriteLine($"Suite: {suitePrice:F2} lv.");
        }
    }
}
