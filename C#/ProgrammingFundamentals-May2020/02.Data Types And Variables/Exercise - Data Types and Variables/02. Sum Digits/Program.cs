using System;

namespace _02._Sum_Digits
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                int currentDigit = int.Parse(number[i].ToString());
                sum += currentDigit;
            }

            Console.WriteLine(sum);
        }
    }
}
