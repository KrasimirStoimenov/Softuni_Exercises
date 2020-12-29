using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Pokemon_Don_t_Go
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            int sum = 0;

            Proccessing(numbers, ref sum);

            Console.WriteLine(sum);
        }

        static void Proccessing(List<int> numbers, ref int sum)
        {
            while (numbers.Any())
            {
                int index = int.Parse(Console.ReadLine());
                int currentNumber = 0;
                if (index < 0 || index > numbers.Count - 1)
                {
                    int removedNumber = 0;
                    InvalidIndexProccessed(numbers, index, ref removedNumber);
                    currentNumber = removedNumber;
                }
                else
                {
                    currentNumber = numbers[index];
                    numbers.RemoveAt(index);
                }

                sum += currentNumber;

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] <= currentNumber)
                    {
                        numbers[i] += currentNumber;
                    }
                    else
                    {
                        numbers[i] -= currentNumber;
                    }
                }
            }
        }

        static void InvalidIndexProccessed(List<int> numbers, int index, ref int removedNumber)
        {
            if (index < 0)
            {
                removedNumber = numbers[0];
                numbers.RemoveAt(0);
                int lastElement = numbers.Last();
                numbers.Insert(0, lastElement);
            }
            else if (index > numbers.Count - 1)
            {
                removedNumber = numbers[numbers.Count - 1];
                numbers.RemoveAt(numbers.Count - 1);
                int firstElement = numbers[0];
                numbers.Add(firstElement);
            }
        }
    }
}
