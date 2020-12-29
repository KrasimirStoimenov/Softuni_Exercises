using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArgs = ReadIntArray();
            int elementsToDeque = inputArgs[1];
            int magicNumber = inputArgs[2];

            int[] numbersArray = ReadIntArray();
            Queue<int> numbers = new Queue<int>(numbersArray);
            DequeElementsInQueue(numbers, elementsToDeque);
            PrintOutput(numbers, magicNumber);
        }

        static void PrintOutput(Queue<int> numbers, int magicNumber)
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

        static void DequeElementsInQueue(Queue<int> numbers, int elementsToDeque)
        {
            for (int i = 0; i < elementsToDeque; i++)
            {
                if (numbers.Count > 0)
                {
                    numbers.Dequeue();
                }
            }
        }

        static int[] ReadIntArray() => Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();


    }
}
