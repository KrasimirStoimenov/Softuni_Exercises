using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int desiredLength = int.Parse(Console.ReadLine());
            Func<string, bool> nameLengthChecker = x => x.Length <= desiredLength;

            Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(nameLengthChecker)
                .ToList()
                .ForEach(x => Console.WriteLine(x));
        }
    }
}
