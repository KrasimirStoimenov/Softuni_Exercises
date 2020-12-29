using System;
using System.Text.RegularExpressions;

namespace _02._Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());
            int successfulRegistrationsCount = 0;

            for (int i = 0; i < inputCount; i++)
            {
                string currentInput = Console.ReadLine();
                string pattern = @"(U\$)(?<username>[A-Z][a-z]{2,})\1(P@\$)(?<password>[A-Za-z]{5,}[0-9]+)\2";
                Match match = Regex.Match(currentInput, pattern);
                if (match.Success)
                {
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {match.Groups["username"].Value}, Password: {match.Groups["password"].Value}");
                    successfulRegistrationsCount++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {successfulRegistrationsCount}");
        }
    }
}
