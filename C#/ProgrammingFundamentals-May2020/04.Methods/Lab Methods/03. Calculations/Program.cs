using System;

namespace _03._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string @operator = Console.ReadLine();
            short firstNumber = short.Parse(Console.ReadLine());
            short secondNumber = short.Parse(Console.ReadLine());
            int result = 0;
            switch (@operator)
            {
                case "add":
                    result = GetResultAddCase(@operator, firstNumber, secondNumber);
                    break;
                case "multiply":
                    result = GetResultMultiplyCase(@operator, firstNumber, secondNumber);
                    break;
                case "subtract":
                    result = GetResultSubstractCase(@operator, firstNumber, secondNumber);
                    break;
                case "divide":
                    result = GetResultDivideCase(@operator, firstNumber, secondNumber);
                    break;
            }

            Console.WriteLine(result);
        }

        static int GetResultDivideCase(string @operator, short firstNumber, short secondNumber)
        {
            return firstNumber / secondNumber;
        }

        static int GetResultSubstractCase(string @operator, short firstNumber, short secondNumber)
        {
            return firstNumber - secondNumber;
        }

        static int GetResultAddCase(string @operator, short firstNumber, short secondNumber)
        {
            return firstNumber + secondNumber;
        }
        static int GetResultMultiplyCase(string @operator, short firstNumber, short secondNumber)
        {
            return firstNumber * secondNumber;
        }


    }
}
