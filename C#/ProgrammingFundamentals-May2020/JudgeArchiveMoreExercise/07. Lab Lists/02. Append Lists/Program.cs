using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02._Append_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(new char[] { '|' })
                .ToList();
            StringBuilder sb = new StringBuilder();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                string[] arguments = list[i].Split(' ').ToArray();
                for (int j = 0; j < arguments.Length; j++)
                {
                    sb.Append(arguments[j]+ " ");
                }
            }
            Console.WriteLine(sb);
        }
    }
}
