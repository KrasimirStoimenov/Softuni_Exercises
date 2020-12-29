using System;

namespace _01.ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> iterator = new ListyIterator<string>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (cmdArgs[0])
                {
                    case "Create":
                        string[] initialParams = new string[cmdArgs.Length - 1];
                        for (int i = 1; i < cmdArgs.Length; i++)
                        {
                            initialParams[i - 1] = cmdArgs[i];
                        }
                        iterator.Create(initialParams);
                        break;
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                    case "Print":
                        iterator.Print();
                        break;
                }
            }
        }
    }
}
