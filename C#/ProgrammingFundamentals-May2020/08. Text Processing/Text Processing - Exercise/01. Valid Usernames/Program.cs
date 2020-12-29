using System;
using System.Linq;

namespace _01._Valid_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine()
                .Split(", ")
                .ToArray();

            foreach (var user in usernames)
            {
                if (HasValidCharacters(user) && HasValidLength(user))
                {
                    Console.WriteLine(user);
                }
            }
        }

        static bool HasValidLength(string user)
        {
            if (user.Length >= 3 && user.Length <= 16)
            {
                return true;
            }

            return false;
        }

        static bool HasValidCharacters(string user)
        {
            foreach (var character in user)
            {
                if (!(char.IsLetterOrDigit(character)) && character != '-' && character != '_')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
