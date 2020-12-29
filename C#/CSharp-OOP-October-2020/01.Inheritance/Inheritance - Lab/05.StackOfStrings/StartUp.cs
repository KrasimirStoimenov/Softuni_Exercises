using System;
using System.Collections.Generic;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();

            stack.Push("1");
            stack.Push("2");
            stack.Push("3");

            Console.WriteLine(stack.IsEmpty());

            Stack<string> range = new Stack<string>();

            range.Push("a");
            range.Push("b");
            range.Push("c");

            stack.AddRange(range);

            while (stack.Count>0)
            {
                Console.WriteLine(stack.Pop());
            }


        }
    }
}
