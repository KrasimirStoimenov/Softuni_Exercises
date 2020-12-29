using System;
using System.Linq;

namespace _05._Rounding_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                double currentNumber = numbers[i];
                double rounded = Math.Round(currentNumber, MidpointRounding.AwayFromZero);

                Console.WriteLine($"{Convert.ToDecimal(numbers[i])} => {Convert.ToInt32(rounded)}");
            }
        }
    }
}
