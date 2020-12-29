using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printNames = x => Console.WriteLine(x);

            Console.ReadLine()
                .Split(" ")
                .ToList()
                .ForEach(printNames);
        }
    }
}
