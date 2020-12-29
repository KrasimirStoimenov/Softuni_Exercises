using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] setsLength = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int firstSetLength = setsLength[0];
            int secondSetLength = setsLength[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            FillingSets(firstSet, firstSetLength);
            FillingSets(secondSet, secondSetLength);

            foreach (var item in firstSet)
            {
                if (secondSet.Contains(item))
                {
                    Console.Write(item + " ");
                }
            }
        }

        static void FillingSets(HashSet<int> set, int length)
        {
            for (int i = 0; i < length; i++)
            {
                int number = int.Parse(Console.ReadLine());
                set.Add(number);
            }
        }
    }
}
