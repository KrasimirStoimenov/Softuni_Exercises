using System;
using System.Linq;
using System.Collections.Generic;

namespace _08._Custom_Comparator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            var evenNumbers = numbers.Where(x => x % 2 == 0).ToList();
            var oddNumbers = numbers.Where(x => x % 2 != 0).ToList();

            evenNumbers.Sort();
            oddNumbers.Sort();
            var resultList = new List<int>();

            foreach (var number in evenNumbers)
            {
                resultList.Add(number);
            }

            foreach (var number in oddNumbers)
            {
                resultList.Add(number);
            }

            Console.WriteLine(string.Join(" ", resultList));
        }
    }
}
