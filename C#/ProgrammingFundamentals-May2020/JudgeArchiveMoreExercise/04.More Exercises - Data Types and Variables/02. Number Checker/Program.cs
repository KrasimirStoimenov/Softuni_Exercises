using System;

namespace _02._Number_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isInteger = long.TryParse(Console.ReadLine(), out long resultInt);

            if (isInteger)
            {
                Console.WriteLine("integer");
            }
            else 
            {
                Console.WriteLine("floating-point");
            }
        }
    }
}
