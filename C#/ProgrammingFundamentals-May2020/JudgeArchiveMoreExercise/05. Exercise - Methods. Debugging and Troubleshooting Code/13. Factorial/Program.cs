using System;
using System.Numerics;

namespace _13._Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(Factorial(number));
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
    }
}
