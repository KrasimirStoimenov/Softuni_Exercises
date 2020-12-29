using System;
using System.Linq;

namespace _02.Number_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();

                switch (cmdArgs[0])
                {
                    case "Switch":
                        int index = int.Parse(cmdArgs[1]);
                        if (index >= 0 && index < numbers.Length)
                        {
                            numbers[index] *= -1;
                        }
                        break;
                    case "Change":
                        int indexChange = int.Parse(cmdArgs[1]);
                        int value = int.Parse(cmdArgs[2]);
                        if (indexChange >= 0 && indexChange < numbers.Length)
                        {
                            numbers[indexChange] = value;
                        }
                        break;
                    case "Sum":
                        if (cmdArgs[1] == "Negative")
                        {
                            int sum = 0;
                            foreach (var number in numbers)
                            {
                                if (number < 0)
                                {
                                    sum += number;
                                }
                            }
                            Console.WriteLine(sum);
                        }
                        else if (cmdArgs[1] == "Positive")
                        {
                            int sum = 0;
                            foreach (var number in numbers)
                            {
                                if (number >= 0)
                                {
                                    sum += number;
                                }
                            }
                            Console.WriteLine(sum);
                        }
                        else if (cmdArgs[1] == "All")
                        {
                            Console.WriteLine(numbers.Sum());
                        }
                        break;

                }
            }

            foreach (var number in numbers)
            {
                if (number >= 0)
                {
                    Console.Write(number+ " ");
                }
            }
        }
    }
}
