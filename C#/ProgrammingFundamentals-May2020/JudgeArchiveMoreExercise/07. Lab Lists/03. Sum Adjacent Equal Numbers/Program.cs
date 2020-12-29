using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Sum_Adjacent_Equal_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<decimal> list = Console.ReadLine()
                .Split()
                .Select(decimal.Parse)
                .ToList();

            for (int i = 0; i < list.Count - 1; i++)
            {

                if (list[i] == list[i + 1])
                {
                    list[i] = list[i] + list[i + 1];
                    list.RemoveAt(i + 1);
                    i = -1;
                }
            }
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
