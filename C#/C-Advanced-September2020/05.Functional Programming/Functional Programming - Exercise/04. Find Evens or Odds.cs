using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rangeArgs = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int start = rangeArgs[0];
            int end = rangeArgs[1];

            List<int> numbersInRange = new List<int>();
            FillNumbersInRange(numbersInRange, start, end);

            string criteria = Console.ReadLine();
            Predicate<int> predicate = Predicate(criteria);

            numbersInRange.Where(x => predicate(x)).ToList().ForEach(x => Console.Write(x + " "));

        }

        private static void FillNumbersInRange(List<int> numbersInRange, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                numbersInRange.Add(i);
            }
        }

        static Predicate<int> Predicate(string criteria)
        {
            if (criteria == "odd")
            {
                return x => x % 2 != 0;
            }
            else if (criteria == "even")
            {
                return x => x % 2 == 0;
            }

            return null;
        }
    }
}
