using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Contact_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> contacts = Console.ReadLine()
                .Split(" ")
                .ToList();

            while (true)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                switch (cmdArgs[0])
                {
                    case "Add":
                        string contact = cmdArgs[1];
                        int index = int.Parse(cmdArgs[2]);

                        if (!contacts.Contains(contact))
                        {
                            contacts.Add(contact);
                        }
                        else
                        {
                            if (index >= 0 && index < contacts.Count)
                            {
                                contacts.Insert(index, contact);
                            }
                        }
                        break;
                    case "Remove":
                        int contactToRemoveIndex = int.Parse(cmdArgs[1]);
                        if (contactToRemoveIndex >= 0 && contactToRemoveIndex < contacts.Count)
                        {
                            contacts.RemoveAt(contactToRemoveIndex);
                        }
                        break;
                    case "Export":
                        int startIndex = int.Parse(cmdArgs[1]);
                        int count = int.Parse(cmdArgs[2]);

                        for (int i = startIndex; i < startIndex + count; i++)
                        {
                            if (i > contacts.Count - 1)
                            {
                                break;
                            }
                            else
                            {
                                Console.Write(contacts[i] + " ");
                            }
                        }
                        Console.WriteLine();
                        break;
                    case "Print":
                        if (cmdArgs[1] == "Normal")
                        {
                            Console.WriteLine($"Contacts: {string.Join(" ", contacts)} ");
                            return;
                        }
                        else if (cmdArgs[1] == "Reversed")
                        {
                            contacts.Reverse();
                            Console.WriteLine($"Contacts: {string.Join(" ", contacts)} ");

                            return;
                        }
                        break;

                }
            }

        }
    }
}
