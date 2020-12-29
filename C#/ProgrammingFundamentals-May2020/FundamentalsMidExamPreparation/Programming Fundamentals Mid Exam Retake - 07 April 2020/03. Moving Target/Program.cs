using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Moving_Target
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targetsList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Proccessing(targetsList);

            Console.WriteLine(string.Join("|", targetsList));
        }

        static void Proccessing(List<int> targetsList)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();

                ManipulatingTargetList(cmdArgs, targetsList);
            }
        }

        static void ManipulatingTargetList(string[] cmdArgs, List<int> targetList)
        {
            string command = cmdArgs[0];
            int index = int.Parse(cmdArgs[1]);
            int power = int.Parse(cmdArgs[2]);
            switch (command)
            {
                case "Shoot":
                    if (index >= 0 && index < targetList.Count)
                    {
                        targetList[index] -= power;
                        if (targetList[index] <= 0)
                        {
                            targetList.RemoveAt(index);
                        }
                    }
                    break;
                case "Add":
                    if (index >= 0 && index < targetList.Count)
                    {
                        targetList.Insert(index, power);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                    break;
                case "Strike":
                    if (index + power >= targetList.Count || index - power < 0)
                    {
                        Console.WriteLine("Strike missed!");
                    }
                    else
                    {
                        int removeFrom = index - power;
                        int removeElements = power * 2 + 1;
                        targetList.RemoveRange(removeFrom, removeElements);
                    }
                    break;
            }
        }
    }
}
