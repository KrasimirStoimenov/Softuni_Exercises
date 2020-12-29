using System;
using System.Text;
using System.Collections.Generic;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            Stack<string> changes = new Stack<string>();
            changes.Push(sb.ToString());

            for (int i = 0; i < count; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (cmdArgs[0])
                {
                    case "1":
                        string word = cmdArgs[1];
                        sb.Append(word);
                        changes.Push(sb.ToString());
                        break;
                    case "2":
                        int lastCountToRemove = int.Parse(cmdArgs[1]);
                        sb.Remove(sb.Length - lastCountToRemove, lastCountToRemove);
                        changes.Push(sb.ToString());
                        break;
                    case "3":
                        int index = int.Parse(cmdArgs[1]);
                        Console.WriteLine(sb[index-1]);
                        break;
                    case "4":
                        changes.Pop();
                        sb.Clear();
                        sb.Append(changes.Peek());
                        break;
                }
            }
        }
    }
}
