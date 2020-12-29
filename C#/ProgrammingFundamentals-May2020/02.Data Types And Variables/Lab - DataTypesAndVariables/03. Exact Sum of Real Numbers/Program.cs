using System;
using System.Numerics;

namespace _03._Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            decimal sum = 0m;
            for (int i = 0; i < numbers; i++)
            {
                decimal currentNumber = decimal.Parse(Console.ReadLine());
                sum += currentNumber;
            }

            Console.WriteLine(sum);
        }
    }
}
