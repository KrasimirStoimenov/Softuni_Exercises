using System;
using System.Linq;

namespace _02.Tasks_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tasks = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(" ");

                switch (cmdArgs[0])
                {
                    case "Complete":
                        Complete(tasks, cmdArgs);
                        break;
                    case "Change":
                        Change(tasks, cmdArgs);
                        break;
                    case "Drop":
                        Drop(tasks, cmdArgs);
                        break;
                    case "Count":
                        CountProccess(tasks, cmdArgs);
                        break;
                }

            }
            var result = tasks.Where(x => x > 0);
            Console.WriteLine(string.Join(" ", result));

        }

        static void CountProccess(int[] tasks, string[] cmdArgs)
        {
            string taskProccess = cmdArgs[1];
            if (taskProccess == "Completed")
            {
                int counter = 0;
                foreach (var task in tasks)
                {
                    if (task == 0)
                    {
                        counter++;
                    }
                }
                Console.WriteLine(counter);
            }
            else if (taskProccess == "Incomplete")
            {
                int counter = 0;
                foreach (var task in tasks)
                {
                    if (task > 0)
                    {
                        counter++;
                    }
                }
                Console.WriteLine(counter);
            }
            else if (taskProccess == "Dropped")
            {
                int counter = 0;
                foreach (var task in tasks)
                {
                    if (task < 0)
                    {
                        counter++;
                    }
                }
                Console.WriteLine(counter);
            }
        }

        static void Drop(int[] task, string[] cmdArgs)
        {
            int dropIndex = int.Parse(cmdArgs[1]);
            if (dropIndex >= 0 && dropIndex < task.Length)
            {
                task[dropIndex] = -1;
            }
        }

        static void Change(int[] task, string[] cmdArgs)
        {
            int changeIndex = int.Parse(cmdArgs[1]);
            int time = int.Parse(cmdArgs[2]);
            if (changeIndex >= 0 && changeIndex < task.Length)
            {
                task[changeIndex] = time;
            }
        }

        static void Complete(int[] task, string[] cmdArgs)
        {
            int completeIndex = int.Parse(cmdArgs[1]);
            if (completeIndex >= 0 && completeIndex < task.Length)
            {
                task[completeIndex] = 0;
            }
        }
    }
}
