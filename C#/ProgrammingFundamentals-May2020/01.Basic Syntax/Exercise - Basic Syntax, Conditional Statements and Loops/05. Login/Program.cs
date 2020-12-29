using System;

namespace _05._Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";

            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            bool hasLoggedIn = false;

            for (int i = 0; i < 3; i++)
            {
                string checkedPassword = Console.ReadLine();
                if (checkedPassword == password)
                {
                    hasLoggedIn = true;
                    break;
                }
                Console.WriteLine("Incorrect password. Try again.");
            }

            if (hasLoggedIn)
            {
                Console.WriteLine($"User {username} logged in.");
            }
            else
            {
                Console.WriteLine($"User {username} blocked!");

            }
        }
    }
}
