using System;

namespace _02._Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal pound = decimal.Parse(Console.ReadLine());

            decimal USD = pound * 1.31m;

            Console.WriteLine($"{USD:F3}");
        }
    }
}
