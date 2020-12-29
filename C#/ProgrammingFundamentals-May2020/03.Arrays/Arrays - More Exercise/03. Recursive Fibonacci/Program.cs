using System;

namespace _03._Recursive_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int fibonacciNumber = GetFibonacci(number);

            Console.WriteLine(fibonacciNumber);
        }
        private static int GetFibonacci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }
            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }


    }
}
