namespace _03._The_Final_Quest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(" ")
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = command.Split();

                string action = cmdArgs[0];
                switch (action)
                {
                    case "Delete":
                        int index = int.Parse(cmdArgs[1]);
                        if (index + 1 < list.Count)
                        {
                            list.RemoveAt(index + 1);
                        }
                        break;
                    case "Swap":
                        SwapMethod(list, cmdArgs);
                        break;
                    case "Put":
                        PutMethod(list, cmdArgs);
                        break;
                    case "Sort":
                        list = list.OrderByDescending(x => x).ToList();
                        break;
                    case "Replace":
                        ReplaceMethod(list, cmdArgs);
                        break;

                }
            }
            Console.WriteLine(string.Join(" ", list));


        }

        static void PutMethod(List<string> list, string[] cmdArgs)
        {
            string word = cmdArgs[1];
            int indexPut = int.Parse(cmdArgs[2]);
            if (indexPut == list.Count+1)
            {
                list.Add(word);
            }
            else if (indexPut <= list.Count && indexPut > 0)
            {
                list.Insert(indexPut - 1, word);
            }

        }

        static void SwapMethod(List<string> list, string[] cmdArgs)
        {
            string firstWord = cmdArgs[1];
            string secondWord = cmdArgs[2];
            int firstWordIndex = 0;
            int secondWordIndex = 0;
            if (list.Contains(firstWord) && list.Contains(secondWord))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    string currentWord = list[i];
                    if (currentWord == firstWord)
                    {
                        firstWordIndex = i;
                    }
                    else if (currentWord == secondWord)
                    {
                        secondWordIndex = i;
                    }
                }

                string temp = list[secondWordIndex];
                list[secondWordIndex] = list[firstWordIndex];
                list[firstWordIndex] = temp;

            }
        }

        static void ReplaceMethod(List<string> list, string[] cmdArgs)
        {
            string firstWordReplace = cmdArgs[1];
            string secondWordReplace = cmdArgs[2];
            int secondWordIndexReplace = 0;
            if (list.Contains(secondWordReplace))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    string current = list[i];

                    if (current == secondWordReplace)
                    {
                        secondWordIndexReplace = i;
                    }
                }

                list[secondWordIndexReplace] = firstWordReplace;
            }
        }
    }
}
