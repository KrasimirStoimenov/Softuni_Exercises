using System;
using System.Collections.Generic;

namespace _07._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> regularGuestList = new HashSet<string>();
            HashSet<string> VIPGuestList = new HashSet<string>();
            AddingGuestsInGuestList(regularGuestList, VIPGuestList);
            GuestsActuallyCome(regularGuestList, VIPGuestList);
            PrintOutput(regularGuestList, VIPGuestList);
        }

        static void PrintOutput(HashSet<string> regularGuestList, HashSet<string> VIPGuestList)
        {
            int guestDidntCameToParty = VIPGuestList.Count + regularGuestList.Count;
            Console.WriteLine(guestDidntCameToParty);
            if (VIPGuestList.Count > 0)
            {
                Console.WriteLine(string.Join("\n", VIPGuestList));
            }
            if (regularGuestList.Count > 0)
            {
                Console.WriteLine(string.Join("\n", regularGuestList));
            }
        }

        static void GuestsActuallyCome(HashSet<string> regularGuestList, HashSet<string> VIPGuestList)
        {
            string guest;
            while ((guest = Console.ReadLine()) != "END")
            {
                char firstChar = guest[0];
                if (char.IsDigit(firstChar))
                {
                    VIPGuestList.Remove(guest);
                }
                else
                {
                    regularGuestList.Remove(guest);
                }
            }
        }

        static void AddingGuestsInGuestList(HashSet<string> regularGuestList, HashSet<string> VIPGuestList)
        {
            string guest;
            while ((guest = Console.ReadLine()) != "PARTY")
            {
                char firstChar = guest[0];
                if (char.IsDigit(firstChar))
                {
                    VIPGuestList.Add(guest);
                }
                else
                {
                    regularGuestList.Add(guest);
                }
            }
        }
    }
}
