using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._Append_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split('|', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            StringBuilder sb = new StringBuilder();

            for (int i = list.Count - 1; i >= 0; i--)
            {
                string[] currentElements = list[i].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int j = 0; j < currentElements.Length; j++)
                {

                    sb.Append(currentElements[j]+ " ");
                }

            }
            Console.WriteLine(sb);
        }
    }
}
