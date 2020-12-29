using System;
using System.Collections.Generic;

namespace _07.__Primes_in_Given_Range
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());

            List<int> primeNumbersInRange = PrimesInRange(start, finish);

            Console.WriteLine(string.Join(", ", primeNumbersInRange));
        }
        static List<int> PrimesInRange(int start, int finish)
        {
            List<int> primeNumbers = new List<int>();
            for (int i = start; i <= finish; i++)
            {
                if (IsPrime(i))
                {
                    primeNumbers.Add(i);
                }
            }
            return primeNumbers;
        }
        static bool IsPrime(long number)
        {
            if (number == 0 || number == 1)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
