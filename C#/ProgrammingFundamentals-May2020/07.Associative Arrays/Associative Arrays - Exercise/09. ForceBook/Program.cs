using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();

            Proccessing(sides);
            PrintOutput(sides);
        }

        static void PrintOutput(Dictionary<string, List<string>> sides)
        {
            sides = sides.Where(c => c.Value.Count > 0)
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(n => n.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in sides)
            {
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");

                var orderedUserList = kvp.Value.OrderBy(x => x).ToList();
                foreach (var user in orderedUserList)
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }

        static void Proccessing(Dictionary<string, List<string>> sides)
        {
            string command;
            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                if (command.Contains("|"))
                {
                    string[] cmdArgs = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    AddingUsersToSides(cmdArgs[0], cmdArgs[1], "|", sides);
                }
                else if (command.Contains("->"))
                {
                    string[] cmdArgs = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    AddingUsersToSides(cmdArgs[1], cmdArgs[0], "->", sides);
                }
            }
        }

        static void AddingUsersToSides(string forceSide, string forceUser, string delimeter, Dictionary<string, List<string>> sides)
        {
            if (delimeter == "|")
            {
                if (!ValidateIfUserExist(sides, forceUser))
                {
                    if (sides.ContainsKey(forceSide))
                    {
                        if (!sides[forceSide].Contains(forceUser))
                        {
                            sides[forceSide].Add(forceUser);
                        }
                    }
                    else
                    {
                        sides.Add(forceSide, new List<string>() { forceUser });
                    }
                }
            }
            else if (delimeter == "->")
            {
                if (ValidateIfUserExist(sides, forceUser))
                {
                    foreach (var kvp in sides)
                    {
                        kvp.Value.Remove(forceUser);
                    }

                    if (sides.ContainsKey(forceSide))
                    {
                        sides[forceSide].Add(forceUser);
                    }
                    else
                    {
                        sides.Add(forceSide, new List<string>() { forceUser });
                    }
                }
                else
                {
                    if (sides.ContainsKey(forceSide))
                    {
                        sides[forceSide].Add(forceUser);

                    }
                    else
                    {
                        sides.Add(forceSide, new List<string>() { forceUser });
                    }
                }
                Console.WriteLine($"{forceUser} joins the {forceSide} side!");
            }
        }

        static bool ValidateIfUserExist(Dictionary<string, List<string>> sides, string forceUser)
        {
            foreach (var kvp in sides)
            {
                if (kvp.Value.Contains(forceUser))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
