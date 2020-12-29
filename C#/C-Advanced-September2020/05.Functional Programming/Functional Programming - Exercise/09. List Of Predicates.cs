using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            FillNumbersList(numbers);

            int[] sequenceOfNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Func<int, bool> validationFunc = number =>
            {
                foreach (var num in sequenceOfNumbers)
                {
                    if (number % num != 0)
                    {
                        return false;
                    }
                }
                return true;
            };

            numbers.Where(validationFunc).ToList().ForEach(x => Console.Write(x + " "));
        }

        private static void FillNumbersList(List<int> numbers)
        {
            int end = int.Parse(Console.ReadLine());
            for (int i = 1; i <= end; i++)
            {
                numbers.Add(i);
            }
        }
    }
}
