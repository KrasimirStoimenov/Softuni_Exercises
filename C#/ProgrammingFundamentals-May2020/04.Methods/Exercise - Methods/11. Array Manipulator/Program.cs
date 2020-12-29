using System;
using System.Linq;
using System.Collections.Generic;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split();

                switch (cmdArgs[0])
                {
                    case "exchange":
                        int indexForExchange = int.Parse(cmdArgs[1]);
                        if (indexForExchange < 0 || indexForExchange >= numbers.Length)
                        {
                            Console.WriteLine("Invalid index");
                            continue;
                        }
                        numbers = GetExchangedArray(numbers, indexForExchange);
                        break;
                    case "max":
                        int maxIndex = GetMaxIndex(cmdArgs[1], numbers);
                        if (maxIndex == -1)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(maxIndex);
                        }
                        break;
                    case "min":
                        int minIndex = GetMinIndex(cmdArgs[1], numbers);
                        if (minIndex == -1)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(minIndex);
                        }
                        break;
                    case "first":
                        int count = int.Parse(cmdArgs[1]);
                        if (count > numbers.Length || count < 0)
                        {
                            Console.WriteLine("Invalid count");
                            continue;
                        }
                        List<int> firstCountArray = GetFirst(cmdArgs[2], count, numbers);
                        if (firstCountArray.Count == 0)
                        {
                            Console.WriteLine("[]");
                        }
                        else
                        {
                            Console.WriteLine($"[{string.Join(", ", firstCountArray)}]");
                        }
                        break;
                    case "last":
                        int counter = int.Parse(cmdArgs[1]);
                        if (counter > numbers.Length || counter < 0)
                        {
                            Console.WriteLine("Invalid count");
                            continue;
                        }
                        List<int> lastCountArray = GetLast(cmdArgs[2], counter, numbers);
                        if (lastCountArray.Count == 0)
                        {
                            Console.WriteLine("[]");
                        }
                        else
                        {
                            Console.WriteLine($"[{string.Join(", ", lastCountArray)}]");
                        }
                        break;
                }
            }
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        private static List<int> GetLast(string command, int counter, int[] numbers)
        {
            List<int> lastCounterArr = new List<int>();
            numbers = numbers.Reverse().ToArray();
            int currentCounter = 0;
            if (command == "even")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        lastCounterArr.Add(numbers[i]);
                        currentCounter++;
                    }
                    if (currentCounter == counter)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 != 0)
                    {
                        lastCounterArr.Add(numbers[i]);
                        currentCounter++;
                    }
                    if (currentCounter == counter)
                    {
                        break;
                    }
                }
            }
            numbers = numbers.Reverse().ToArray();
            lastCounterArr.Reverse();
            return lastCounterArr;
        }

        static List<int> GetFirst(string command, int count, int[] numbers)
        {
            List<int> firstCountArr = new List<int>();
            int currentCounter = 0;
            if (command == "even")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        firstCountArr.Add(numbers[i]);
                        currentCounter++;
                    }
                    if (currentCounter == count)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 != 0)
                    {
                        firstCountArr.Add(numbers[i]);
                        currentCounter++;
                    }
                    if (currentCounter == count)
                    {
                        break;
                    }
                }
            }
            return firstCountArr;
        }

        static int GetMinIndex(string command, int[] numbers)
        {
            int minIndex = 0;
            int minNumber = int.MaxValue;
            if (command == "even")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 0 && numbers[i] <= minNumber)
                    {
                        minIndex = i;
                        minNumber = numbers[i];
                    }
                }
                if (minNumber == int.MaxValue)
                {
                    return -1;
                }
            }
            else if (command == "odd")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 != 0 && numbers[i] <= minNumber)
                    {
                        minIndex = i;
                        minNumber = numbers[i];
                    }
                }
                if (minNumber == int.MaxValue)
                {
                    return -1;
                }
            }
            return minIndex;
        }
        static int GetMaxIndex(string command, int[] numbers)
        {
            int maxIndex = 0;
            int maxNumber = int.MinValue;
            if (command == "even")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 == 0 && numbers[i] >= maxNumber)
                    {
                        maxIndex = i;
                        maxNumber = numbers[i];
                    }
                }
                if (maxNumber == int.MinValue)
                {
                    return -1;
                }
            }
            else if (command == "odd")
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] % 2 != 0 && numbers[i] >= maxNumber)
                    {
                        maxIndex = i;
                        maxNumber = numbers[i];
                    }
                }
                if (maxNumber == int.MinValue)
                {
                    return -1;
                }
            }
            return maxIndex;
        }
        static int[] GetExchangedArray(int[] numbers, int indexForExchange)
        {
            int[] exchangedArray = new int[numbers.Length];

            for (int i = indexForExchange + 1; i < numbers.Length; i++)
            {
                exchangedArray[i - indexForExchange - 1] = numbers[i];
            }
            for (int i = 0; i <= indexForExchange; i++)
            {
                exchangedArray[numbers.Length - 1 - indexForExchange + i] = numbers[i];
            }

            return exchangedArray;
        }
    }
}
