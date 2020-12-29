using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Change_List
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
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split();

                if (cmdArgs[0] == "Delete")
                {
                    DeleteNumbersFromList(numbers, int.Parse(cmdArgs[1]));
                }
                else if (cmdArgs[0] == "Insert")
                {
                    InsertNumbersToList(numbers, int.Parse(cmdArgs[1]), int.Parse(cmdArgs[2]));
                }
            }
        }
        static void DeleteNumbersFromList(List<int> list, int number)
        {
            list.RemoveAll(n=>n==number);
        }
        static void InsertNumbersToList(List<int> list, int number, int index)
        {
            list.Insert(index, number);
        }
    }
}
