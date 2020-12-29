using System;

namespace _04._Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            bool[] isPrimes = new bool[numbers + 1];
            for (int i = 0; i <= numbers; i++)
            {
                isPrimes[i] = true;
            }
            isPrimes[0] = false;
            isPrimes[1] = false;
            for (int p = 0; p < numbers; p++)
            {
                if (isPrimes[p])
                {
                    for (int j = 2; j * p <= numbers; j++)
                    {
                        isPrimes[j * p] = false;
                    }
                }
            }
            for (int i = 0; i < isPrimes.Length; i++)
            {
                if (isPrimes[i])
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
