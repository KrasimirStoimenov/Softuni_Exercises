using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            foreach (var @char in input)
            {
                if (stack.Count > 0)
                {
                    char stackLastSymbol = stack.Peek();

                    if (@char == ')' && stackLastSymbol == '('
                        || @char == '}' && stackLastSymbol == '{'
                        || @char == ']' && stackLastSymbol == '[')
                    {
                        stack.Pop();
                        continue;
                    }
                }
                stack.Push(@char);

            }

            Console.WriteLine(stack.Count > 0 ? "NO" : "YES");
        }
    }
}
