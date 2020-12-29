using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> chemicalElements = new HashSet<string>();

            AddElementsInTheSet(chemicalElements);
            PrintOrderedElements(chemicalElements);
        }

        static void PrintOrderedElements(HashSet<string> chemicalElements)
        {
            foreach (var element in chemicalElements.OrderBy(x => x))
            {
                Console.Write(element + " ");
            }
        }

        static void AddElementsInTheSet(HashSet<string> chemicalElements)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] elements = Console.ReadLine().Split(" ").ToArray();

                foreach (var el in elements)
                {
                    chemicalElements.Add(el);
                }
            }
        }
    }
}
