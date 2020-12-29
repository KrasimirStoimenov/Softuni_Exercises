using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Remove_Negatives_and_Reverse
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Where(x => x > 0)
                .Reverse()
                .ToList();
            if (list.Count <= 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                list.ForEach(i => Console.Write(i + " "));
            }
        }
    }
}
