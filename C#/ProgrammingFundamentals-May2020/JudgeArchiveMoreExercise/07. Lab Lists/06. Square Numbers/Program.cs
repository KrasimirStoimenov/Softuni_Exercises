using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Square_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> list = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            List<double> squareNumberList = new List<double>();

            for (int i = 0; i < list.Count; i++)
            {
                if (Math.Sqrt(list[i]) == (int)Math.Sqrt(list[i]))
                {
                    squareNumberList.Add(list[i]);
                }
            }

            Console.WriteLine(string.Join(" ", squareNumberList.OrderByDescending(x => x)));

        }
    }
}
