using System;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> users = new Dictionary<string, string>();

            Proccessing(users);
            PrintOutput(users);
        }

        static void PrintOutput(Dictionary<string, string> users)
        {
            foreach (var kvp in users)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }

        static void Proccessing(Dictionary<string, string> users)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();

                switch (cmdArgs[0])
                {
                    case "register":
                        RegisterProccess(users, cmdArgs);
                        break;
                    case "unregister":
                        UnregisterProccess(users, cmdArgs);
                        break;
                }
            }
        }

        static void UnregisterProccess(Dictionary<string, string> users, string[] cmdArgs)
        {
            string user = cmdArgs[1];

            if (!Validator(user, users))
            {
                Console.WriteLine($"ERROR: user {user} not found");
            }
            else
            {
                Console.WriteLine($"{user} unregistered successfully");
            }
            users.Remove(user);
        }

        static void RegisterProccess(Dictionary<string, string> users, string[] cmdArgs)
        {
            string user = cmdArgs[1];
            string licensePlateNumber = cmdArgs[2];

            if (!Validator(user, users))
            {
                users.Add(user, licensePlateNumber);
                Console.WriteLine($"{user} registered {licensePlateNumber} successfully");
            }
            else
            {
                Console.WriteLine($"ERROR: already registered with plate number {users[user]}");
            }
        }

        static bool Validator(string user, Dictionary<string, string> users)
        {
            if (users.ContainsKey(user))
            {
                return true;
            }

            return false;
        }
    }
}
