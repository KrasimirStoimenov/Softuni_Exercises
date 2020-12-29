using System;
using System.Text;

namespace _05._Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberAsString = Console.ReadLine().TrimStart('0');
            int multiplyer = int.Parse(Console.ReadLine());
            string reversedNumber = ReverseString(numberAsString);

            if (multiplyer == 0)
            {
                Console.WriteLine("0");
                return;
            }
            StringBuilder sb = new StringBuilder();
            int remainder = 0;

            for (int i = 0; i < reversedNumber.Length; i++)
            {
                int currentNumber = int.Parse(reversedNumber[i].ToString());
                int resultNumber = currentNumber * multiplyer + remainder;
                remainder = resultNumber / 10;
                sb.Append(resultNumber % 10);
            }
            if (remainder > 0)
            {
                sb.Append(remainder);
            }

            Console.WriteLine(ReverseString(sb.ToString()));
        }

        static string ReverseString(string numberAsString)
        {
            StringBuilder result = new StringBuilder();

            for (int i = numberAsString.Length - 1; i >= 0; i--)
            {
                result.Append(numberAsString[i]);
            }

            return result.ToString();
        }
    }
}
