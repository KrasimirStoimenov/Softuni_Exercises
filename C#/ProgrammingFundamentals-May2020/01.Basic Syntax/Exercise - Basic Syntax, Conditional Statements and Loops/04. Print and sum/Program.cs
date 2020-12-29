using System;

namespace _04._Print_and_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int sum = 0;
            string result = "";
            for (int i = start; i <= end; i++)
            {
                result += i + " ";
                sum += i;
            }
            Console.WriteLine(result);
            Console.WriteLine("Sum: " + sum);
        }
    }
}
