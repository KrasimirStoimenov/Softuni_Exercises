namespace Froggy_Squad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var listOfFrogs = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ');

                switch (cmdArgs[0])
                {
                    case "Join":
                        string frogName = cmdArgs[1];
                        listOfFrogs.Add(frogName);
                        break;
                    case "Jump":
                        string frog = cmdArgs[1];
                        int index = int.Parse(cmdArgs[2]);
                        if (IndexValidator(index, listOfFrogs))
                        {
                            listOfFrogs.Insert(index, frog);
                        }
                        break;
                    case "Dive":
                        int indexToRemove = int.Parse(cmdArgs[1]);
                        if (IndexValidator(indexToRemove, listOfFrogs))
                        {
                            listOfFrogs.RemoveAt(indexToRemove);
                        }
                        break;
                    case "First":
                        List<string> printFirst = GetFirstOrLastCount(listOfFrogs, cmdArgs);
                        Console.WriteLine(string.Join(" ", printFirst));
                        break;
                    case "Last":
                        listOfFrogs.Reverse();
                        List<string> printLast = GetFirstOrLastCount(listOfFrogs, cmdArgs);
                        printLast.Reverse();
                        Console.WriteLine(string.Join(" ", printLast));
                        listOfFrogs.Reverse();
                        break;
                    case "Print":
                        if (cmdArgs[1] == "Normal")
                        {
                            Console.WriteLine("Frogs: " + string.Join(" ", listOfFrogs));
                            return;
                        }
                        else if (cmdArgs[1] == "Reversed")
                        {
                            listOfFrogs.Reverse();
                            Console.WriteLine("Frogs: " + string.Join(" ", listOfFrogs));
                            return;
                        }

                        break;
                }
            }
        }
        static List<string> GetFirstOrLastCount(List<string> listOfFrogs, string[] cmdArgs)
        {
            List<string> firstOrLastFrogs = new List<string>();
            int count = int.Parse(cmdArgs[1]);
            for (int i = 0; i < count; i++)
            {
                if (i >= listOfFrogs.Count)
                {
                    break;
                }
                string currentFrog = listOfFrogs[i];
                firstOrLastFrogs.Add(currentFrog);
            }
            return firstOrLastFrogs;
        }
        static bool IndexValidator(int index, List<string> frogs)
        {
            if (index >= 0 && index < frogs.Count)
            {
                return true;
            }

            return false;
        }
    }
}