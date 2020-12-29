using System;
using System.Linq;
using System.Text;

namespace _01.Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            ProccessingProgram(username);
        }

        static void ProccessingProgram(string username)
        {
            StringBuilder sbUsername = new StringBuilder(username);
            string command;
            while ((command = Console.ReadLine()) != "Sign up")
            {
                string[] cmdArgs = command.Split(" ");

                switch (cmdArgs[0])
                {
                    case "Case":
                        if (cmdArgs[1] == "lower")
                        {
                            string toLower = sbUsername.ToString().ToLower();
                            sbUsername.Clear();
                            sbUsername.Append(toLower);
                        }
                        else if (cmdArgs[1] == "upper")
                        {
                            string toUpper = sbUsername.ToString().ToUpper();
                            sbUsername.Clear();
                            sbUsername.Append(toUpper);
                        }
                        break;
                    case "Reverse":
                        int reverseStartIndex = int.Parse(cmdArgs[1]);
                        int reverseEndIndex = int.Parse(cmdArgs[2]);
                        if (ValidateIndexes(reverseStartIndex, reverseEndIndex, sbUsername))
                        {
                            string substring = sbUsername.ToString().Substring(reverseStartIndex, reverseEndIndex - reverseStartIndex+1);
                            char[] reversedSubstring = substring.Reverse().ToArray();
                            Console.WriteLine(string.Join("", reversedSubstring));
                            continue;
                        }
                        else
                        {
                            continue;
                        }
                    case "Cut":
                        string cutSubstring = cmdArgs[1];
                        if (sbUsername.ToString().Contains(cutSubstring))
                        {
                            int indexOfCutSubstring = sbUsername.ToString().IndexOf(cutSubstring);
                            sbUsername.Remove(indexOfCutSubstring, cutSubstring.Length);
                        }
                        else
                        {
                            Console.WriteLine($"The word {sbUsername} doesn't contain {cutSubstring}.");
                            continue;
                        }
                        break;
                    case "Replace":
                        char charToReplace = char.Parse(cmdArgs[1]);
                        sbUsername.Replace(charToReplace, '*');
                        break;
                    case "Check":
                        char charToCheck = char.Parse(cmdArgs[1]);
                        if (sbUsername.ToString().Contains(charToCheck))
                        {
                            Console.WriteLine("Valid");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine($"Your username must contain {charToCheck}.");
                            continue;
                        }

                }

                Console.WriteLine(sbUsername);
            }
        }

        static bool ValidateIndexes(int startIndex, int endIndex, StringBuilder sbUsername)
        {
            if ((startIndex >= 0 && startIndex < sbUsername.Length)
                && (endIndex >= 0 && endIndex < sbUsername.Length))
            {
                return true;
            }

            return false;
        }
    }
}
