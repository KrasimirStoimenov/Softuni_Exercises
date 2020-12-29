using System;

namespace _04._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            PrindValidPasswords(password);
        }
        static void PrindValidPasswords(string password)
        {
            if (HasSixToTenCharacters(password)
                && ConsistOnlyLettersAndDigits(password)
                && HaveAtLeastTwoDigits(password))
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!HasSixToTenCharacters(password))
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (!ConsistOnlyLettersAndDigits(password))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (!HaveAtLeastTwoDigits(password))
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
        }
        static bool HasSixToTenCharacters(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }
            return false;
        }
        static bool ConsistOnlyLettersAndDigits(string password)
        {
            foreach (var character in password)
            {
                if (!char.IsLetterOrDigit(character))
                {
                    return false;
                }
            }
            return true;
        }
        static bool HaveAtLeastTwoDigits(string password)
        {
            int digitCounter = 0;

            foreach (var character in password)
            {
                if (char.IsDigit(character))
                {
                    digitCounter++;
                }
            }
            if (digitCounter >= 2)
            {
                return true;
            }
            return false;
        }
    }
}
