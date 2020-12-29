using System;

namespace _10._Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                int currentNumber = i;
                bool isTopNumber = Validator(currentNumber);
                if (isTopNumber)
                {
                    Console.WriteLine(currentNumber);
                }
            }
        }
        static bool Validator(int num)
        {
            int sum = 0;
            int currentNumber = 0;
            bool hasOneOddDigit = false;
            while (num != 0)
            {
                currentNumber = num % 10;
                if (currentNumber % 2 == 1)
                {
                    hasOneOddDigit = true;
                }
                sum += currentNumber;
                num /= 10;
            }
            if (sum % 8 == 0 && hasOneOddDigit)
            {
                return true;
            }
            return false;
        }
    }
}
