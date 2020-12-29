using System;
using System.Text;

namespace _04._Numbers_in_Reversed_Order
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            Console.WriteLine(GetNumberReversed(number));
        }
        static string GetNumberReversed(string number)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = number.Length - 1; i >= 0; i--)
            {
                sb.Append(number[i]);
            }
            return sb.ToString();
        }
    }
}
