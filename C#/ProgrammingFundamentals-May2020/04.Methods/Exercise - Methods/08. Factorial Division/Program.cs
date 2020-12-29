using System;

namespace _08._Factorial_Division
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            double result = GetFactorialResult(firstNumber, secondNumber);
            Console.WriteLine($"{result:F2}");
        }
        static double GetFactorialResult(double first, double second)
        {
            double firstFactorial = Factorial(first);
            double secondFactorial = Factorial(second);

            return firstFactorial / secondFactorial;
        }
        static double Factorial(double number)
        {
            double sum = 1;
            for (int i = (int)number; i > 0; i--)
            {
                sum *= i;
            }
            return sum;
        }
    }
}
