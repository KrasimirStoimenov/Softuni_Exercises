using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Inbox_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string/*user*/, List<string>/*emails*/> userEmails = new Dictionary<string, List<string>>();

            Proccessing(userEmails);
            PrintOutput(userEmails);
        }

        static void PrintOutput(Dictionary<string, List<string>> userEmails)
        {
            Console.WriteLine($"Users count: {userEmails.Count}");
            foreach (var user in userEmails.OrderByDescending(count => count.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine(user.Key);
                foreach (var email in user.Value)
                {
                    Console.WriteLine($"- {email}");
                }
            }
        }

        static void Proccessing(Dictionary<string, List<string>> userEmails)
        {
            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] cmdArgs = command.Split("->");
                string action = cmdArgs[0];
                string username = cmdArgs[1];
                switch (action)
                {
                    case "Add":
                        AddMethod(userEmails, username);
                        break;
                    case "Send":
                        SendEmailMethod(userEmails, username, cmdArgs[2]);
                        break;
                    case "Delete":
                        DeleteUser(userEmails, username);
                        break;
                }
            }
        }

        static void DeleteUser(Dictionary<string, List<string>> userEmails, string username)
        {
            if (userEmails.ContainsKey(username))
            {
                userEmails.Remove(username);
            }
            else
            {
                Console.WriteLine($"{username} not found!");
            }
        }

        static void SendEmailMethod(Dictionary<string, List<string>> userEmails, string username, string email)
        {
            userEmails[username].Add(email);
        }

        static void AddMethod(Dictionary<string, List<string>> userEmails, string username)
        {
            if (userEmails.ContainsKey(username))
            {
                Console.WriteLine($"{username} is already registered");
            }
            else
            {
                userEmails.Add(username, new List<string>());
            }
        }
    }
}
