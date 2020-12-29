using System;
using System.Numerics;
namespace _02._From_Left_to_The_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] arr = Console.ReadLine()
                    .Split(' ');
                BigInteger firstNumber = BigInteger.Parse(arr[0]);
                BigInteger secondNumber = BigInteger.Parse(arr[1]);

                if (firstNumber >= secondNumber)
                {
                    BigInteger sum = BigInteger.Abs(GetSum(firstNumber));
                    Console.WriteLine(sum);
                }
                else
                {
                    BigInteger sum = BigInteger.Abs(GetSum(secondNumber));
                    Console.WriteLine(sum);
                }


            }
        }
        static BigInteger GetSum(BigInteger num)
        {
            BigInteger sum = 0;
            while (num != 0)
            {
                sum += num % 10;
                num = num / 10;
            }

            return sum;
        }
    }
}
