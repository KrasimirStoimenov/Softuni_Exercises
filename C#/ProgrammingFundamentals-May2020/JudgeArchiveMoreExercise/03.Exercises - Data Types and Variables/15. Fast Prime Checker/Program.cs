using System;

namespace _15._Fast_Prime_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumbers = int.Parse(Console.ReadLine());
            for (int i = 2; i <= countNumbers; i++)
            {
                bool isPrime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                Console.WriteLine($"{i} -> {isPrime}");

            }
        }
    }
}
