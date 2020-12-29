using System;
using System.Numerics;

namespace _03._Big_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            BigInteger bigNumber = factorial(number);
            Console.WriteLine(bigNumber);
        }
        static BigInteger factorial(int number)
        {
            BigInteger num = 1;

            for (int i = 1; i <= number; i++)
            {
                num *= i;
            }

            return num;
        }
    }
}
