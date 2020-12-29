using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(x => x > 0)
                .ToList();
            if (list.Any())
            {
                list.Reverse();
                list.ForEach(x => Console.WriteLine(x));
            }
            else
            {
                Console.WriteLine("empty");
            }

        }
    }
}
