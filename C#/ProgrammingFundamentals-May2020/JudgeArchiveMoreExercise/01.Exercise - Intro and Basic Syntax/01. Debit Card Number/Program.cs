using System;

namespace _01._Debit_Card_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            Console.WriteLine($"{a:D4} {b:d4} {c:d4} {d:d4}");
        }
    }
}
