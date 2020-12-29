using System;

namespace _03.Stack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (command.StartsWith("Push"))
                {
                    string[] cmdArgs = command.Split(new char[] { ' ', ',' },StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 1; i < cmdArgs.Length; i++)
                    {
                        stack.Push(int.Parse(cmdArgs[i]));
                    }
                }
                else if (command.StartsWith("Pop"))
                {
                    if (stack.Count == 0)
                    {
                        Console.WriteLine("No elements");
                        continue;
                    }
                    stack.Pop();
                    
                }
            }
            for (int i = 0; i < 2; i++)
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
