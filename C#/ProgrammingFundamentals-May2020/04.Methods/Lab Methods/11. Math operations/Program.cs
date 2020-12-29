using System;

namespace _11._Math_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

            int result = GetResult(firstNumber, @operator, secondNumber);
            Console.WriteLine(result);
        }

        static int GetResult(int num1, string oper, int num2)
        {
            int result = 0;
            switch (oper)
            {
                case "/":
                    result = num1 / num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;

            }
            return result;
        }
    }
}
