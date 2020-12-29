using System;

namespace _10._Multiply_Evens_by_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            int result = GetMultipleOfEvensAndOdds(number);
            Console.WriteLine(result);
        }

        static int GetMultipleOfEvensAndOdds(int number)
        {
            int oddSum = 0;
            int evenSum = 0;
            while (number != 0)
            {
                int currenNumber = number % 10;
                if (currenNumber % 2 == 0)
                {
                    evenSum += currenNumber;
                }
                else
                {
                    oddSum += currenNumber;
                }
                number /= 10;
            }

            return evenSum * oddSum;
        }
    }
}
