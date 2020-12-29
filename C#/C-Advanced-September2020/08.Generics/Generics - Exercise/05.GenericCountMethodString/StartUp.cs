using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodString
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> elements = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                elements.Add(input);
            }

            string compareElement = Console.ReadLine();
            int countBiggerElements = CompareClass.Compare(elements,compareElement);

            Console.WriteLine(countBiggerElements);
        }
    }
}
