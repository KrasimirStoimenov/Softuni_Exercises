using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<decimal, decimal> VAT = x => x * 1.20m;

            Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(VAT)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x:F2}"));
        }
    }
}
