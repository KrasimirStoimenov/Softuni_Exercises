using System;
using System.Numerics;

namespace _14._Factorial_Trailing_Zeroes
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            BigInteger factorialNumber = Factorial(number);
            Console.WriteLine(TrailingZeroes(factorialNumber));
        }
        static BigInteger Factorial(int number)
        {
            BigInteger sum = 1;
            for (int i = 1; i <= number; i++)
            {
                sum *= i;
            }

            return sum;
        }
        static int TrailingZeroes(BigInteger factorial)
        {
            string numberAsString = factorial.ToString();
            int countTrailingZeroes = 0;

            for (int i = numberAsString.Length - 1; i >= 0; i--)
            {
                if (numberAsString[i] == '0')
                {
                    countTrailingZeroes++;
                }
                else
                {
                    break;
                }
            }
            return countTrailingZeroes;
        }
    }
}
