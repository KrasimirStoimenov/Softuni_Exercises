using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetCharSum = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

            Func<string, int> asciiSum = x => x.Select(c => (int)c).Sum();
            Func<string, int, bool> func = (x, y) => asciiSum(x) >= y;

            Func<string[], int, Func<string, int, bool>, string> firstName = (names, targetCharSum, func) 
                => names.FirstOrDefault(n => func(n, targetCharSum));

            string firstValidName = firstName(names, targetCharSum, func);

            Console.WriteLine(firstValidName);

        }
    }
}
