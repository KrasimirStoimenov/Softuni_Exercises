using System;
using System.ComponentModel.DataAnnotations;

namespace _09._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                bool isPalindrome = Validator(command);
                Console.WriteLine(isPalindrome.ToString().ToLower());
            }

        }

        static bool Validator(string num)
        {
            string result = string.Empty;
            for (int i = num.Length - 1; i >= 0; i--)
            {
                result += num[i];
            }
            if (result == num)
            {
                return true;
            }
            return false;
        }
    }
}
