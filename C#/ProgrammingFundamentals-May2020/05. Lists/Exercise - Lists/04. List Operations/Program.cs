using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._List_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Proccessing(numbers);
            Console.WriteLine(string.Join(" ", numbers));
        }
        static void Proccessing(List<int> numbers)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();
                switch (cmdArgs[0])
                {
                    case "Add":
                        AddNumberToList(int.Parse(cmdArgs[1]), numbers);
                        break;
                    case "Insert":
                        InsertNumberToList(int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2]), numbers);
                        break;
                    case "Remove":
                        RemoveNumberFromList(int.Parse(cmdArgs[1]), numbers);
                        break;
                    case "Shift":
                        ShiftNumbersInList(cmdArgs[1], int.Parse(cmdArgs[2]), numbers);
                        break;

                }
            }
        }
        static void ShiftNumbersInList(string direction, int count, List<int> list)
        {
            int optimizedCount = count % list.Count;
            if (direction == "left")
            {
                for (int i = 0; i < optimizedCount; i++)
                {
                    int temp = list[0];
                    for (int j = 0; j < list.Count - 1; j++)
                    {
                        list[j] = list[j + 1];
                    }
                    list[list.Count - 1] = temp;
                }
            }
            else if (direction == "right")
            {
                for (int i = 0; i < optimizedCount; i++)
                {
                    int temp = list[list.Count - 1];
                    for (int j = list.Count - 1; j > 0; j--)
                    {
                        list[j] = list[j - 1];
                    }
                    list[0] = temp;
                }
            }
        }
        static void RemoveNumberFromList(int index, List<int> list)
        {
            if (IndexValidator(index, list))
            {
                list.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Invalid index");
            }
        }
        static void InsertNumberToList(int number, int index, List<int> list)
        {
            if (IndexValidator(index, list))
            {
                list.Insert(index, number);
            }
            else
            {
                Console.WriteLine("Invalid index");

            }
        }
        static void AddNumberToList(int number, List<int> numbers)
        {
            numbers.Add(number);
        }
        static bool IndexValidator(int index, List<int> list)
        {
            if (index < 0 || index > list.Count)
            {
                return false;
            }
            return true;
        }
    }
}
