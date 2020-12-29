using System;
using System.Text;

namespace _01._Warrior_s_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Proccessing(input);
        }

        static void Proccessing(string input)
        {
            string inputDecipher = input;
            string command;
            while ((command = Console.ReadLine()) != "For Azeroth")
            {
                string[] cmdArgs = command.Split(" ");
                switch (cmdArgs[0])
                {
                    case "GladiatorStance":
                        inputDecipher = inputDecipher.ToUpper();
                        break;
                    case "DefensiveStance":
                        inputDecipher = inputDecipher.ToLower();
                        break;
                    case "Dispel":
                        int index = int.Parse(cmdArgs[1]);
                        if (index < 0 || index > inputDecipher.Length - 1)
                        {
                            Console.WriteLine("Dispel too weak.");
                            continue;
                        }
                        else
                        {
                            char letter = char.Parse(cmdArgs[2]);
                            char findLetterToReplace = char.Parse(inputDecipher.Substring(index, 1));
                            int indexOfFirstLetter = inputDecipher.IndexOf(findLetterToReplace);
                            inputDecipher = inputDecipher.Remove(indexOfFirstLetter, 1).Insert(indexOfFirstLetter, letter.ToString());
                            Console.WriteLine("Success!");
                            continue;
                        }
                    case "Target":
                        string action = cmdArgs[1];

                        if (action == "Change")
                        {
                            string substring = cmdArgs[2];
                            string secondSubstring = cmdArgs[3];
                            inputDecipher = inputDecipher.Replace(substring, secondSubstring);
                        }
                        else if (action == "Remove")
                        {
                            string substring = cmdArgs[2];
                            int indexToRemove = inputDecipher.IndexOf(substring);
                            inputDecipher = inputDecipher.Remove(indexToRemove, substring.Length);
                        }
                        else
                        {
                            Console.WriteLine("Command doesn't exist!");
                            continue;
                        }
                        break;
                    default:
                        Console.WriteLine("Command doesn't exist!");
                        continue;
                }
                Console.WriteLine(inputDecipher);
            }
        }
    }
}
