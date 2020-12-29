using System;

namespace _03._Last_K_Numbers_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int numbers = int.Parse(Console.ReadLine());

            long[] array = new long[count];
            array[0] = 1;
            for (int i = 1; i < count; i++)
            {
                long sum = 0;
                int start = Math.Max(0, i - numbers);
                for (int j = start; j < i; j++)
                {
                    sum += array[j];
                }
                array[i] = sum;

            }
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
