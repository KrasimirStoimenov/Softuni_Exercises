using System;

namespace _10._Multiplication_Table2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int multiplyer = int.Parse(Console.ReadLine());
            if (multiplyer > 10)
            {
                Console.WriteLine($"{num} X {multiplyer} = {num * multiplyer}");
                return;
            }

            for (int i = multiplyer; i <= 10; i++)
            {
                Console.WriteLine($"{num} X {i} = {num * i}");
            }
        }
    }
}
