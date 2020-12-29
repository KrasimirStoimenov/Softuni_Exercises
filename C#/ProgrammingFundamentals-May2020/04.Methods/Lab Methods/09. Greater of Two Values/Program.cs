using System;

namespace _09._Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            switch (type)
            {
                case "int":
                    PrintMaxInt();
                    break;
                case "char":
                    PrintMaxChar();
                    break;
                case "string":
                    PrintMaxString();
                    break;
            }
        }

        static void PrintMaxString()
        {
            string firstString = Console.ReadLine();
            string secondString = Console.ReadLine();

            if (firstString.CompareTo(secondString)>0)
            {
                Console.WriteLine(firstString);
            }
            else
            {
                Console.WriteLine(secondString);
            }
        }

        static void PrintMaxChar()
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());

            if (firstChar > secondChar)
            {
                Console.WriteLine(firstChar);
            }
            else
            {
                Console.WriteLine(secondChar);
            }
        }

        static void PrintMaxInt()
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            if (firstNumber > secondNumber)
            {
                Console.WriteLine(firstNumber);
            }
            else
            {
                Console.WriteLine(secondNumber);
            }
        }
    }
}
