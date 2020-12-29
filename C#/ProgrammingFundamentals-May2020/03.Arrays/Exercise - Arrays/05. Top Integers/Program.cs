﻿using System;
using System.Linq;

namespace _05._Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNumber = numbers[i];
                bool isTopInteger = true;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[j] >= currentNumber)
                    {
                        isTopInteger = false;
                        break;
                    }
                }
                if (isTopInteger)
                {
                    Console.Write(currentNumber + " ");
                }
            }
        }
    }
}
