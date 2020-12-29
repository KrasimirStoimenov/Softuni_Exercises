using System;

namespace _03._Miles_to_Kilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal miles = decimal.Parse(Console.ReadLine());
            decimal kilometers = miles * 1.60934m;

            Console.WriteLine($"{kilometers:F2}");
        }
    }
}
