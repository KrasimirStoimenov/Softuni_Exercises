using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Count_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Dictionary<int, int> dict = new Dictionary<int, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                if (dict.ContainsKey(currentNumber))
                {
                    dict[currentNumber]++;
                }
                else
                {
                    dict.Add(currentNumber, 1);
                }
            }
            
            foreach (var kvp in dict.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{kvp.Key}-> {kvp.Value}");
            }
        }
    }
}
