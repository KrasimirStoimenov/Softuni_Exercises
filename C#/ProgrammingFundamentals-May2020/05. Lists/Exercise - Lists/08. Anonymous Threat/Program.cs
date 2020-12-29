using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Anonymous_Threat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Console.WriteLine(string.Join(" ", Proccessing(list)));
        }
        static List<string> Proccessing(List<string> list)
        {
            string command;
            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] cmdArgs = command.Split();
                if (cmdArgs[0] == "merge")
                {
                    GetMergedList(list, cmdArgs[1], cmdArgs[2]);
                }
                else if (cmdArgs[0] == "divide")
                {
                    GetDividedList(list, cmdArgs[1], cmdArgs[2]);
                }
            }

            return list;
        }
        static List<string> GetMergedList(List<string> list, string start, string end)
        {
            int startIndex = int.Parse(start);
            int endIndex = int.Parse(end);
            if (startIndex > list.Count - 1)
            {
                return list;
            }
            if (startIndex < 0)
            {
                startIndex = 0;
            }
            if (endIndex > list.Count - 1)
            {
                endIndex = list.Count - 1;
            }
            string merged = string.Empty;
            for (int i = startIndex; i <= endIndex; i++)
            {
                merged += list[i];
            }
            list.RemoveRange(startIndex, endIndex - startIndex + 1);
            list.Insert(startIndex, merged);

            return list;
        }
        static List<string> GetDividedList(List<string> list, string ind, string part)
        {
            int index = int.Parse(ind);
            int partition = int.Parse(part);
            if (index >= 0 && index <= list.Count - 1)
            {
                string word = list[index];
                List<string> dividedList = new List<string>();
                int startIndex = 0;
                int lengthToAdd = word.Length / partition;
                for (int i = 0; i < partition; i++)
                {
                    if (i==partition -1)
                    {
                        dividedList.Add(word.Substring(startIndex, word.Length - startIndex));
                    }
                    else
                    {
                        dividedList.Add(word.Substring(startIndex, lengthToAdd));
                        startIndex += lengthToAdd;
                    }
                }

                list.RemoveAt(index);
                list.InsertRange(index, dividedList);
            }

            return list;
        }


    }
}
