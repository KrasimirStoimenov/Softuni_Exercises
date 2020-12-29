using System;
using System.Linq;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            Proccessing(ref activationKey);

            Console.WriteLine($"Your activation key is: {activationKey}");
        }

        static void Proccessing(ref string activationKey)
        {
            string command;
            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] cmdArgs = command.Split(">>>").ToArray();
                switch (cmdArgs[0])
                {
                    case "Contains":
                        string someWord = cmdArgs[1];
                        if (activationKey.Contains(someWord))
                        {
                            Console.WriteLine($"{activationKey} contains {someWord}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        string action = cmdArgs[1];
                        int startIndexToFlip = int.Parse(cmdArgs[2]);
                        int endIndexToFlip = int.Parse(cmdArgs[3]);
                        string substring = activationKey.Substring(startIndexToFlip, endIndexToFlip - startIndexToFlip);
                        if (action == "Upper")
                        {
                            activationKey = activationKey.Replace(substring, substring.ToUpper());
                        }
                        else
                        {
                            activationKey = activationKey.Replace(substring, substring.ToLower());
                        }

                        Console.WriteLine(activationKey);
                        break;
                    case "Slice":
                        int startIndexToSlice = int.Parse(cmdArgs[1]);
                        int endIndexToSlice = int.Parse(cmdArgs[2]);
                        activationKey = activationKey.Remove(startIndexToSlice, endIndexToSlice - startIndexToSlice);

                        Console.WriteLine(activationKey);
                        break;

                }
            }
        }
    }
}
