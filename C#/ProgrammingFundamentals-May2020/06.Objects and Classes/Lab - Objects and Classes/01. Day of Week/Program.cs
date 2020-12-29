using System;

namespace _01._Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            DateTime date = DateTime.ParseExact(input, "dd-M-yyyy", System.Globalization.CultureInfo.InvariantCulture);

            Console.WriteLine(date.DayOfWeek);
        }
    }
}
