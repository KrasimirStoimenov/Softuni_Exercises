using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._List_Manipulation_Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bool shouldPrintOriginalList = false;
            string command;
            command = Proccessing(list, ref shouldPrintOriginalList);
            if (shouldPrintOriginalList)
            {
                Console.WriteLine(string.Join(" ", list));
            }
        }

        static string Proccessing(List<int> list, ref bool shouldPrintOriginalList)
        {
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split();

                switch (cmdArgs[0])
                {
                    case "Add":
                        AddToList(list, cmdArgs);
                        shouldPrintOriginalList = true;
                        break;
                    case "Remove":
                        RemoveFromList(list, cmdArgs);
                        shouldPrintOriginalList = true;
                        break;
                    case "RemoveAt":
                        RemoveAtIndex(list, cmdArgs);
                        shouldPrintOriginalList = true;
                        break;
                    case "Insert":
                        InsertAtIndex(list, cmdArgs);
                        shouldPrintOriginalList = true;
                        break;
                    case "Contains":
                        PrintConstrains(list, cmdArgs);
                        break;
                    case "PrintEven":
                        PrintEven(list);
                        break;
                    case "PrintOdd":
                        PrintOdd(list);
                        break;
                    case "GetSum":
                        PrintListSum(list);
                        break;
                    case "Filter":
                        FilterProccessing(list, cmdArgs);
                        break;
                }

            }

            return command;
        }

        static void FilterProccessing(List<int> list, string[] cmdArgs)
        {
            string condition = cmdArgs[1];
            int filterNumber = int.Parse(cmdArgs[2]);
            if (condition == "<")
            {
                var resultListFilter = list.Where(x => x < filterNumber);
                Console.WriteLine(string.Join(" ", resultListFilter));
            }
            else if (condition == ">")
            {
                var resultListFilter = list.Where(x => x > filterNumber);
                Console.WriteLine(string.Join(" ", resultListFilter));
            }
            else if (condition == ">=")
            {
                var resultListFilter = list.Where(x => x >= filterNumber);
                Console.WriteLine(string.Join(" ", resultListFilter));
            }
            else if (condition == "<=")
            {
                var resultListFilter = list.Where(x => x <= filterNumber);
                Console.WriteLine(string.Join(" ", resultListFilter));
            }
        }

        static void PrintListSum(List<int> list)
        {
            Console.WriteLine(list.Sum());
        }

        static void PrintOdd(List<int> list)
        {
            var resultListOdd = list.Where(x => x % 2 != 0).ToList();
            Console.WriteLine(string.Join(" ", resultListOdd));
        }

        static void PrintEven(List<int> list)
        {
            var resultList = list.Where(x => x % 2 == 0).ToList();
            Console.WriteLine(string.Join(" ", resultList));
        }

        static void PrintConstrains(List<int> list, string[] cmdArgs)
        {
            int containsNumber = int.Parse(cmdArgs[1]);
            if (list.Contains(containsNumber))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
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
