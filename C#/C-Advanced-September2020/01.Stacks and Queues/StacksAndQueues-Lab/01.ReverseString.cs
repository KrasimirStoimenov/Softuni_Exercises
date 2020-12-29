using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Reverse_String
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Stack<char> stack = new Stack<char>(input);

            while (stack.Any())
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
