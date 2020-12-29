using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            SortedDictionary<int, int> dict = new SortedDictionary<int, int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int current = numbers[i];
                if (dict.ContainsKey(current))
                {
                    dict[current]++;
                }
                else
                {
                    dict.Add(current, 1);
                }
            }
            foreach (var el in dict)
            {
                Console.WriteLine($"{el.Key} -> {el.Value}");
            }
        }
    }
}
