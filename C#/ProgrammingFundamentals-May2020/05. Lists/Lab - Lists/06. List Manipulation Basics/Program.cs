using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._List_Manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Proccessing(list);
            Console.WriteLine(string.Join(" ", list));
        }

        static void Proccessing(List<int> list)
        {
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split();

                switch (cmdArgs[0])
                {
                    case "Add":
                        AddToList(list, cmdArgs);
                        break;
                    case "Remove":
                        RemoveFromList(list, cmdArgs);
                        break;
                    case "RemoveAt":
                        RemoveAtIndex(list, cmdArgs);
                        break;
                    case "Insert":
                        InsertAtIndex(list, cmdArgs);
                        break;
                }

            }
        }

        static void InsertAtIndex(List<int> list, string[] cmdArgs)
        {
            int insertNumber = int.Parse(cmdArgs[1]);
            int insertIndex = int.Parse(cmdArgs[2]);
            list.Insert(insertIndex, insertNumber);
        }

        static void RemoveAtIndex(List<int> list, string[] cmdArgs)
        {
            int removeIndex = int.Parse(cmdArgs[1]);
            list.RemoveAt(removeIndex);
        }

        static void RemoveFromList(List<int> list, string[] cmdArgs)
        {
            int removeNumber = int.Parse(cmdArgs[1]);
            list.Remove(removeNumber);
        }

        static void AddToList(List<int> list, string[] cmdArgs)
        {
            int addNumber = int.Parse(cmdArgs[1]);
            list.Add(addNumber);
        }
    }
}
