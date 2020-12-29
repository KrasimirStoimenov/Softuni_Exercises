using System;
using System.Linq;

namespace _12._Master_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            PrintMasterNumbersInRange(number);
        }

        static void PrintMasterNumbersInRange(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                if (IsPalindrome(i) && HasValidDigitSum(i) && HasAtLeastOneEvenDigit(i))
                {
                    Console.WriteLine(i);
                }
            }

        }
        static bool HasAtLeastOneEvenDigit(int currentNumber)
        {
            while (currentNumber != 0)
            {
                int current = currentNumber % 10;
                if (current % 2 == 0)
                {
                    return true;
                }
                currentNumber /= 10;
            }
            return false;
        }
        static bool HasValidDigitSum(int currentNumber)
        {
            int sum = 0;
            while (currentNumber != 0)
            {
                sum += currentNumber % 10;
                currentNumber /= 10;
            }

            if (sum % 7 == 0)
            {
                return true;
            }

            return false;
        }
        static bool IsPalindrome(int currentNumber)
        {
            string currentNumberAsString = currentNumber.ToString();
            string result = string.Empty;
            while (currentNumber != 0)
            {
                result += currentNumber % 10;
                currentNumber /= 10;
            }
            if (result == currentNumberAsString)
            {
                return true;
            }


            return false;
        }
    }
}
