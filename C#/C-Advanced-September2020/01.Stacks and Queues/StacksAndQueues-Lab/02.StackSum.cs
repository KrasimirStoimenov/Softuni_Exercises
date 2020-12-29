using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Stack_Sum
{
    class Program
    {
        static void Main()
        {
            int[] numbers = ReadIntArray();
            Stack<int> stack = new Stack<int>(numbers);
            ManipulatingStack(stack);

            Console.WriteLine($"Sum: {stack.Sum()}");
        }

        static void ManipulatingStack(Stack<int> stack)
        {
            string command;
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command.StartsWith("add"))
                {
                    int firstNumber = int.Parse(cmdArgs[1]);
                    int secondNumber = int.Parse(cmdArgs[2]);
                    stack.Push(firstNumber);
                    stack.Push(secondNumber);
                }
                else if (command.StartsWith("remove"))
                {
                    int count = int.Parse(cmdArgs[1]);
                    if (count <= stack.Count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }
        }

        static int[] ReadIntArray() => Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
    }
}
