using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArgs = ReadIntArray();
            int elementsToPop = inputArgs[1];
            int magicNumber = inputArgs[2];

            int[] numbersArray = ReadIntArray();
            Stack<int> numbers = new Stack<int>(numbersArray);
            PopElementsInStack(numbers, elementsToPop);
            PrintOutput(numbers, magicNumber);
        }

        static void PrintOutput(Stack<int> numbers, int magicNumber)
        {
            if (numbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (numbers.Contains(magicNumber))
            {
                Console.WriteLine("true");
            }
            else
            {
                int smallestNumber = int.MaxValue;
                foreach (var number in numbers)
                {
                    if (number < smallestNumber)
                    {
                        smallestNumber = number;
                    }
                }

                Console.WriteLine(smallestNumber);
            }
        }

        static void PopElementsInStack(Stack<int> numbers,int elementsToPop)
        {
            for (int i = 0; i < elementsToPop; i++)
            {
                if (numbers.Count > 0)
                {
                    numbers.Pop();
                }
            }
        }

        static int[] ReadIntArray() => Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();


    }
}
