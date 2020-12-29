using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDouble
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<double> elements = new List<double>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                double input = double.Parse(Console.ReadLine());
                elements.Add(input);
            }

            double compareElement = double.Parse(Console.ReadLine());
            int countBiggerElements = CompareClass.Compare(elements,compareElement);

            Console.WriteLine(countBiggerElements);
        }
    }
}
