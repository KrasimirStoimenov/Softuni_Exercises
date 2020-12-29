using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Mixed_up_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> secondList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> resultList = new List<int>();
            var rangeList = new List<int>();
            secondList.Reverse();
            int min = Math.Min(firstList.Count, secondList.Count);
            for (int i = 0; i < min; i++)
            {
                resultList.Add(firstList[i]);
                resultList.Add(secondList[i]);
            }

            if (firstList.Count > secondList.Count)
            {
                rangeList = firstList.TakeLast(2).ToList();
            }
            else
            {
                rangeList = secondList.TakeLast(2).ToList();
            }
            int minRange = Math.Min(rangeList[0], rangeList[1]);
            int maxRange = Math.Max(rangeList[0], rangeList[1]);
            List<int> finalList = new List<int>();
            foreach (var item in resultList)
            {
                if (item > minRange && item < maxRange)
                {
                    finalList.Add(item);
                }
            }

            finalList.Sort();
            Console.WriteLine(string.Join(" ", finalList));

        }
    }
}
