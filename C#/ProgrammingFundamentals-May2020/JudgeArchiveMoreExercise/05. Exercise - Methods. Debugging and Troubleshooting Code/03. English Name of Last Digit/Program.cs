using System;

namespace _03._English_Name_of_Last_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(LastDigitAsString(input));
        }
        static string LastDigitAsString(string input)
        {
            switch (input[input.Length - 1])
            {
                case '0': return "zero";
                case '1': return "one";
                case '2': return "two";
                case '3': return "three";
                case '4': return "four";
                case '5': return "five";
                case '6': return "six";
                case '7': return "seven";
                case '8': return "eight";
                case '9': return "nine";
            }
            return "invalid";

        }
    }
}
