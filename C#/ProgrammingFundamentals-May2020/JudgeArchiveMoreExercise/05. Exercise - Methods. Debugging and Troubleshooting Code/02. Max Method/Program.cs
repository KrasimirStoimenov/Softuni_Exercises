using System;

namespace _02._Max_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int firstResult = GetMax(first, second);
            Console.WriteLine(GetMax(firstResult, third));
        }
        static int GetMax(int a, int b)
        {
            return Math.Max(a, b);
        }
    }
}
