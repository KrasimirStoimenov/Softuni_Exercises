using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();

            int divider = int.Parse(Console.ReadLine());

            Func<int, bool> divideFunc = x => x % divider != 0;

            numbers.Where(divideFunc).ToList().ForEach(x => Console.Write(x + " "));
        }
    }
}
