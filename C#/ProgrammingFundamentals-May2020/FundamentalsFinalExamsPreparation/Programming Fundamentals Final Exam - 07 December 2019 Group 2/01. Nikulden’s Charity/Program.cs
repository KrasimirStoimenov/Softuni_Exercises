using System;
using System.Text;

namespace _01._Nikulden_s_Charity
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            Proccessing(message);
        }

        static void Proccessing(string message)
        {
            StringBuilder decryptedMessage = new StringBuilder(message);

            string command;
            while ((command = Console.ReadLine()) != "Finish")
            {
                string[] cmdArgs = command.Split(" ");
                string action = cmdArgs[0];
                switch (action)
                {
                    case "Replace":
                        char currentChar = char.Parse(cmdArgs[1]);
                        char newChar = char.Parse(cmdArgs[2]);
                        decryptedMessage.Replace(currentChar, newChar);
                        break;
                    case "Cut":
                        int startIndexToCut = int.Parse(cmdArgs[1]);
                        int endIndexToCut = int.Parse(cmdArgs[2]);
                        if (ValidateIndex(startIndexToCut, endIndexToCut, decryptedMessage))
                        {
                            decryptedMessage.Remove(startIndexToCut, endIndexToCut - startIndexToCut + 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid indexes!");
                            continue;
                        }
                        break;
                    case "Make":
                        if (cmdArgs[1] == "Upper")
                        {
                            string upperCharacters = decryptedMessage.ToString().ToUpper();
                            decryptedMessage.Clear();
                            decryptedMessage.Append(upperCharacters);
                        }
                        else if (cmdArgs[1] == "Lower")
                        {
                            string lowerCharacter = decryptedMessage.ToString().ToLower();
                            decryptedMessage.Clear();
                            decryptedMessage.Append(lowerCharacter);
                        }
                        break;
                    case "Check":
                        string checkString = cmdArgs[1];
                        if (decryptedMessage.ToString().Contains(checkString))
                        {
                            Console.WriteLine($"Message contains {checkString}");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"Message doesn't contain {checkString}");
                            continue;
                        }
                    case "Sum":
                        int startIndexSum = int.Parse(cmdArgs[1]);
                        int endIndexSum = int.Parse(cmdArgs[2]);
                        if (ValidateIndex(startIndexSum, endIndexSum, decryptedMessage))
                        {
                            string substring = decryptedMessage.ToString().Substring(startIndexSum, endIndexSum - startIndexSum + 1);
                            int sum = 0;
                            for (int i = 0; i < substring.Length; i++)
                            {
                                sum += substring[i];
                            }
                            Console.WriteLine(sum);
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Invalid indexes!");
                            continue;
                        }
                }
                Console.WriteLine(decryptedMessage);
            }
        }

        static bool ValidateIndex(int startIndex, int endIndex, StringBuilder decryptedMessage)
        {
            if ((startIndex >= 0 && startIndex < decryptedMessage.Length)
                && (endIndex >= 0 && endIndex < decryptedMessage.Length))
            {
                return true;
            }

            return false;

        }
    }
}
