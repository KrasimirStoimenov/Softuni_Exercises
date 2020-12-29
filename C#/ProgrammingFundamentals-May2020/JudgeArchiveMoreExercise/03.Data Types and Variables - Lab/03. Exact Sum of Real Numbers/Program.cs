using System;

namespace _03._Exact_Sum_of_Real_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            decimal sum = 0m;
            for (int i = 0; i < count; i++)
            {
                decimal num = decimal.Parse(Console.ReadLine());
                sum += num;
            }
            Console.WriteLine(sum);
        }
    }
}
