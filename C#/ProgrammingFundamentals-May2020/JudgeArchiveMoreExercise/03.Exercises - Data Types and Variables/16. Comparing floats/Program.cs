using System;

namespace _16._Comparing_floats
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double result = 0.000000d;
            result = Math.Abs(firstNumber - secondNumber);

            if (result >= 0.000001d)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("True");
            }

        }
    }
}
