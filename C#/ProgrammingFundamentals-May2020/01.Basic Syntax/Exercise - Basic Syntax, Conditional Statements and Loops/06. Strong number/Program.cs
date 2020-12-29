using System;

namespace _06._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int totalSum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                string currentNum = input[i].ToString();
                int factorial = GetFactorial(currentNum);
                totalSum += factorial;
            }

            if (totalSum.ToString() == input)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
        static int GetFactorial(string input)
        {
            int num = int.Parse(input);
            int sum = 1;
            for (int i = num; i >= 1; i--)
            {
                sum = sum * i;
            }

            return sum;
        }
    }
}
