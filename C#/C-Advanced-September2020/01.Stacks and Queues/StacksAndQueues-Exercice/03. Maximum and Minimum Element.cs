using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Stack<int> numbers = new Stack<int>();
            for (int i = 0; i < count; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                switch (cmdArgs[0])
                {
                    case "1":
                        int element = int.Parse(cmdArgs[1]);
                        numbers.Push(element);
                        break;
                    case "2":
                        if (numbers.Any())
                        {
                            numbers.Pop();
                        }
                        break;
                    case "3":
                        if (numbers.Any())
                        {
                            int maxNumber = GetMaxNumber(numbers);
                            Console.WriteLine(maxNumber);
                        }
                        break;
                    case "4":
                        if (numbers.Any())
                        {
                            int minNumber = GetMinNumber(numbers);
                            Console.WriteLine(minNumber);
                        }
                        break;
                }
            }
            if (numbers.Any())
            {
                Console.WriteLine(string.Join(", ", numbers));
            }
        }

        static int GetMaxNumber(Stack<int> numbers)
        {
            int maxNumber = int.MinValue;
            foreach (var number in numbers)
            {
                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }

            return maxNumber;
        }

        static int GetMinNumber(Stack<int> numbers)
        {
            int minNumber = int.MaxValue;
            foreach (var number in numbers)
            {
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }

            return minNumber;
        }
    }
}
