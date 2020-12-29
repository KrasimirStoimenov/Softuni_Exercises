using System;

namespace _06._Interval_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            int smallerNumber = Math.Min(num1, num2);
            int biggerNumber = Math.Max(num1, num2);

            for (int i = smallerNumber; i <= biggerNumber; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
