using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Split_by_Word_Casing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(new char[] { ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' })
                .Where(x => x != "")
                .ToList();
            List<string> lower = new List<string>();
            List<string> upper = new List<string>();
            List<string> mixed = new List<string>();

            Proccessing(list, lower, upper, mixed);

            Console.WriteLine($"Lower-case: {string.Join(", ", lower)}");
            Console.WriteLine($"Mixed-case: {string.Join(", ", mixed)}");
            Console.WriteLine($"Upper-case: {string.Join(", ", upper)}");
        }

        static void Proccessing(List<string> list, List<string> lower, List<string> upper, List<string> mixed)
        {
            for (int i = 0; i < list.Count; i++)
            {
                bool isLower = true;
                bool isUpper = true;
                foreach (var currentChar in list[i])
                {
                    if (!(currentChar >= 97 && currentChar <= 122))
                    {
                        isLower = false;
                    }
                    if (!(currentChar >= 65 && currentChar <= 90))
                    {
                        isUpper = false;
                    }
                }
                if (isLower)
                {
                    lower.Add(list[i]);
                }
                else if (isUpper)
                {
                    upper.Add(list[i]);
                }
                else
                {
                    mixed.Add(list[i]);
                }
            }
        }
    }
}
