using System;
using System.Linq;
using System.Collections.Generic;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ")
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "Party!")
            {
                Func<string, bool> validateGuest = IsValidCriteria(command);
                if (command.StartsWith("Remove"))
                {
                    guests.RemoveAll(x => validateGuest(x));

                }
                else if (command.StartsWith("Double"))
                {
                    for (int i = 0; i < guests.Count; i++)
                    {
                        if (validateGuest(guests[i]))
                        {
                            guests.Insert(i + 1, guests[i]);
                            i++;
                        }
                    }
                }
            }

            if (guests.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
        static Func<string, bool> IsValidCriteria(string command)
        {
            string[] cmdArgs = command.Split(" ").ToArray();
            string criteria = cmdArgs[1];
            string substr = cmdArgs[2];
            switch (criteria)
            {
                case "StartsWith":
                    return x => x.StartsWith(substr);
                case "EndsWith":
                    return x => x.EndsWith(substr);
                case "Length":
                    return x => x.Length == int.Parse(substr);
                default:
                    return null;
            }
        }
    }
}

