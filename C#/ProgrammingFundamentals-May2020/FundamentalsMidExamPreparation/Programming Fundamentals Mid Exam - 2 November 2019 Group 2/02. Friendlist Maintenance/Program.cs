using System;
using System.Linq;

namespace _02._Friendlist_Maintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] friendList = Console.ReadLine()
                .Split(", ");

            string command;
            while ((command = Console.ReadLine()) != "Report")
            {
                string[] cmdArgs = command.Split();

                switch (cmdArgs[0])
                {
                    case "Blacklist":
                        string name = cmdArgs[1];
                        bool nameIsInFriendList = ValidateUser(friendList, name);
                        if (nameIsInFriendList)
                        {
                            for (int i = 0; i < friendList.Length; i++)
                            {
                                if (friendList[i] == name)
                                {
                                    Console.WriteLine($"{friendList[i]} was blacklisted.");
                                    friendList[i] = "Blacklisted";
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{name} was not found.");
                        }
                        break;
                    case "Error":
                        int index = int.Parse(cmdArgs[1]);
                        if (friendList[index] == "Blacklisted" || friendList[index] == "Lost")
                        {
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"{friendList[index]} was lost due to an error.");
                            friendList[index] = "Lost";
                        }
                        break;
                    case "Change":
                        int changeIndex = int.Parse(cmdArgs[1]);
                        string newName = cmdArgs[2];
                        if (changeIndex >= 0 && changeIndex < friendList.Length)
                        {
                            Console.WriteLine($"{friendList[changeIndex]} changed his username to {newName}.");
                            friendList[changeIndex] = newName;
                        }
                        break;
                }
            }

            string[] blacklisted = friendList
                .Where(n => n == "Blacklisted")
                .ToArray();
            string[] lost = friendList
                .Where(n => n == "Lost")
                .ToArray();

            Console.WriteLine($"Blacklisted names: {blacklisted.Length}");
            Console.WriteLine($"Lost names: {lost.Length}");
            Console.WriteLine(string.Join(' ', friendList));

        }

        static bool ValidateUser(string[] friendList, string name)
        {
            foreach (var friendName in friendList)
            {
                if (friendName == name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
