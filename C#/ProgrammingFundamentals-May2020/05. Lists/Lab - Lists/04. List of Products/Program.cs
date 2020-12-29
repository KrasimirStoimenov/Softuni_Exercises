using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                list.Add(input);
            }
            list = list.OrderBy(x => x).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i+1}.{list[i]}");
            }
        }
    }
}
