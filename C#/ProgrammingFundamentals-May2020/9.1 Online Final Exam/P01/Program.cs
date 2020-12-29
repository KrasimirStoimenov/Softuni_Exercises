using System;
using System.Text;

namespace P01
{
    class Program
    {
        static void Main(string[] args)
        {
            string destinations = Console.ReadLine();

            Proccessing(destinations);
        }

        static void Proccessing(string destinations)
        {
            StringBuilder destinationUpdate = new StringBuilder(destinations);
            string command;
            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] cmdArgs = command.Split(":");

                switch (cmdArgs[0])
                {
                    case "Add Stop":
                        AddStopCommand(destinationUpdate, cmdArgs);
                        break;
                    case "Remove Stop":
                        RemoveStopCommand(destinationUpdate, cmdArgs);
                        break;
                    case "Switch":
                        SwitchStopCommand(destinationUpdate, cmdArgs);
                        break;

                }

                Console.WriteLine(destinationUpdate);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {destinationUpdate.ToString()}");
        }

        static void SwitchStopCommand(StringBuilder destinationUpdate, string[] cmdArgs)
        {
            string oldString = cmdArgs[1];
            string newString = cmdArgs[2];

            if (destinationUpdate.ToString().Contains(oldString))
            {
                destinationUpdate.Replace(oldString, newString);
            }
        }

        static void RemoveStopCommand(StringBuilder destinationUpdate, string[] cmdArgs)
        {
            int startIndex = int.Parse(cmdArgs[1]);
            int endIndex = int.Parse(cmdArgs[2]);
            if (ValidateIndex(startIndex, destinationUpdate) && ValidateIndex(endIndex, destinationUpdate))
            {
                destinationUpdate.Remove(startIndex, endIndex - startIndex + 1);
            }
        }

        static void AddStopCommand(StringBuilder destinationUpdate, string[] cmdArgs)
        {
            int index = int.Parse(cmdArgs[1]);
            string destination = cmdArgs[2];
            if (ValidateIndex(index, destinationUpdate))                    //ToCheck if what if index is invalid
            {
                destinationUpdate.Insert(index, destination);
            }
        }

        static bool ValidateIndex(int index, StringBuilder sb)
        {
            if (index >= 0 && index < sb.Length)
            {
                return true;
            }
            return false;
        }
    }
}
