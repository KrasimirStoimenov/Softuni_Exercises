using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!numbers.ContainsKey(number))
                {
                    numbers.Add(number, 0);
                }

                numbers[number]++;
            }

            foreach (var kvp in numbers)
            {
                if (kvp.Value % 2 == 0)
                {
                    Console.WriteLine(kvp.Key);
                    break;
                }
            }
        }
    }
}
