using System;

namespace _07._Exchange_Variable_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            Console.WriteLine("Before:");
            Console.WriteLine($"a = {firstNum}");
            Console.WriteLine($"b = {secondNum}");
            int temp = secondNum;
            secondNum = firstNum;
            firstNum = temp;

            Console.WriteLine("After:");
            Console.WriteLine($"a = {firstNum}");
            Console.WriteLine($"b = {secondNum}");
        }
    }
}
