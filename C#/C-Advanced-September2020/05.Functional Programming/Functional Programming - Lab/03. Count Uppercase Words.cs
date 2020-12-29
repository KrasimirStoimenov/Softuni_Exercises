using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> charChecker = c => char.IsUpper(c[0]);
            Console.ReadLine()
               .Split(" ",StringSplitOptions.RemoveEmptyEntries)
               .Where(charChecker)
               .ToList()
               .ForEach(w => Console.WriteLine(w));
        }
    }
}
