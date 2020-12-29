using System;

namespace _04._Tribonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int[] fibonacciSequence = GetFibonacciSequence(num);
            Console.WriteLine(string.Join(' ', fibonacciSequence));
        }
        static int[] GetFibonacciSequence(int num)
        {
            int[] sequence = new int[num];
            if (num >= 1)
            {
                sequence[0] = 1;
            }
            if (num >= 2)
            {
                sequence[1] = 1;
            }
            if (num >= 3)
            {
                sequence[2] = 2;
            }
            for (int i = 3; i < num; i++)
            {
                int currentNumber = sequence[i-1] + sequence[i - 2] + sequence[i - 3];
                sequence[i] = currentNumber;
            }

            return sequence;
        }
    }
}
