using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Proccessing(numbers);
        }

        static void Proccessing(List<int> numbers)
        {
            double average = numbers.Sum()*1.00 / numbers.Count;

            List<int> biggerNumbersThanAverage = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > average)
                {
                    biggerNumbersThanAverage.Add(numbers[i]);
                }
            }

            biggerNumbersThanAverage = biggerNumbersThanAverage.OrderByDescending(x => x).ToList();

            if (biggerNumbersThanAverage.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }

            if (biggerNumbersThanAverage.Count > 5)
            {
                biggerNumbersThanAverage.RemoveRange(5, biggerNumbersThanAverage.Count - 5);
            }

            Console.WriteLine(string.Join(" ", biggerNumbersThanAverage));
        }
    }
}
