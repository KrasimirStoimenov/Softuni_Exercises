using System;

namespace _05._Fibonacci_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(GetFibonacciNumber(n));
        }
        static int GetFibonacciNumber(int n)
        {
 
            if (n <= 1)
            {
                return 1;
            }
            else
            {
                return GetFibonacciNumber(n - 1) + GetFibonacciNumber(n - 2);
            }
        }
    }
}
