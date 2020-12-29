using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Shopping_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine()
                .Split("!")
                .ToList();

            Proccessing(groceries);

            Console.WriteLine(string.Join(", ", groceries));


        }

        static void Proccessing(List<string> groceries)
        {
            string command;
            while ((command = Console.ReadLine()) != "Go Shopping!")
            {
                string[] cmdArgs = command.Split();

                switch (cmdArgs[0])
                {
                    case "Urgent":
                        if (!ContainsItem(cmdArgs[1], groceries))
                        {
                            groceries.Insert(0, cmdArgs[1]);
                        }
                        break;
                    case "Unnecessary":
                        if (ContainsItem(cmdArgs[1], groceries))
                        {
                            groceries.Remove(cmdArgs[1]);
                        }
                        break;
                    case "Correct":
                        if (ContainsItem(cmdArgs[1], groceries))
                        {
                            int index = groceries.IndexOf(cmdArgs[1]);
                            groceries[index] = cmdArgs[2];
                        }
                        break;
                    case "Rearrange":
                        if (ContainsItem(cmdArgs[1], groceries))
                        {
                            groceries.Remove(cmdArgs[1]);
                            groceries.Add(cmdArgs[1]);
                        }
                        break;
                }
            }
        }

        static bool ContainsItem(string item, List<string> groceries)
        {
            if (groceries.Contains(item))
            {
                return true;
            }
            return false;
        }

    }
}
