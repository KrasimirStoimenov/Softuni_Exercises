using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(ReadTasks());
            Queue<int> threads = new Queue<int>(ReadThreads());
            int valueOfTheTask = int.Parse(Console.ReadLine());
            Processing(tasks, threads, valueOfTheTask);
            PrintOutput(threads, valueOfTheTask);
        }

        private static void PrintOutput(Queue<int> threads, int valueOfTheTask)
        {
            Console.WriteLine($"Thread with value {threads.Peek()} killed task {valueOfTheTask}");

            Console.WriteLine(string.Join(" ", threads));
        }

        private static void Processing(Stack<int> tasks, Queue<int> threads, int valueOfTheTask)
        {


            while (true)
            {
                if (tasks.Peek() == valueOfTheTask)
                {
                    break;
                }

                if (threads.Peek() >= tasks.Peek())
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }
            }
        }

        private static int[] ReadTasks() => Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToArray();
        private static int[] ReadThreads() => Console.ReadLine()
            .Split(" ")
            .Select(int.Parse)
            .ToArray();
    }
}
