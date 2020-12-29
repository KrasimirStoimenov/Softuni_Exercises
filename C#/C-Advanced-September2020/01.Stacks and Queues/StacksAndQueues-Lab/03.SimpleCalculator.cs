using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ").Reverse().ToArray();
            Stack<string> stack = new Stack<string>(input);
            int sum = int.Parse(stack.Pop());
            while (stack.Any())
            {
                string delimeter = stack.Pop();
                int secondNumber = int.Parse(stack.Pop());
                if (delimeter == "+")
                {
                    sum += secondNumber;
                }
                else if (delimeter == "-")
                {
                    sum -= secondNumber;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
