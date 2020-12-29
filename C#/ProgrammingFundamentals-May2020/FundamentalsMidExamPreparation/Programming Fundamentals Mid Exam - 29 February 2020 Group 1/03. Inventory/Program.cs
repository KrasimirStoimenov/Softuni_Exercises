using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split(", ")
                .ToList();

            Proccessing(items);

            Console.WriteLine(string.Join(", ", items));
        }
        static void Proccessing(List<string> items)
        {
            string command;
            while ((command = Console.ReadLine()) != "Craft!")
            {
                string[] cmdArgs = command.Split(" - ");
                switch (cmdArgs[0])
                {
                    case "Collect":
                        CollectMethod(items, cmdArgs[1]);
                        break;
                    case "Drop":
                        DropMethod(items, cmdArgs[1]);
                        break;
                    case "Combine Items":
                        CombineMethod(items, cmdArgs[1]);
                        break;
                    case "Renew":
                        RenewMethod(items, cmdArgs[1]);
                        break;

                }
            }
        }
        static void RenewMethod(List<string> items, string item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                items.Add(item);
            }
        }
        static void CombineMethod(List<string> items, string item)
        {
            string[] combineItems = item.Split(":");

            if (items.Contains(combineItems[0]))
            {
                int index = items.IndexOf(combineItems[0]);
                items.Insert(index + 1, combineItems[1]);
            }
        }
        static void DropMethod(List<string> items, string item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
            }
        }
        static void CollectMethod(List<string> items, string item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
            }
        }
    }
}
