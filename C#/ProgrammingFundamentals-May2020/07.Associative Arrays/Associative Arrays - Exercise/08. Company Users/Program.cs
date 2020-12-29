using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Company_Users
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> users = new Dictionary<string, List<string>>();

            Proccessing(users);
            PrintOutput(users);
        }

        static void PrintOutput(Dictionary<string, List<string>> users)
        {
            users = users.OrderBy(n => n.Key)
                .ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in users)
            {
                Console.WriteLine(kvp.Key);

                foreach (var user in kvp.Value)
                {
                    Console.WriteLine($"-- {user}");
                }
            }
        }

        static void Proccessing(Dictionary<string, List<string>> users)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(" -> ").ToArray();
                string companyName = cmdArgs[0];
                string userId = cmdArgs[1];

                if (!users.ContainsKey(companyName))
                {
                    users.Add(companyName, new List<string>() { userId });
                }
                else
                {
                    if (users[companyName].Contains(userId))
                    {
                        continue;
                    }
                    else
                    {
                        users[companyName].Add(userId);
                    }
                }

            }
        }
    }
}
