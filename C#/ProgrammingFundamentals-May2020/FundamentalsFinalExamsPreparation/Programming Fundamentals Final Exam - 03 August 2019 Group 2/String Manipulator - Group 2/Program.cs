using System;
using System.Text;

namespace String_Manipulator___Group_2
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
            StringBuilder password = new StringBuilder(input);

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                var cmdArgs = command.Split(" ");
                string action = cmdArgs[0];
                switch (action)
                {
                    case "Change":
                        char charToChange = char.Parse(cmdArgs[1]);
                        char charToReplace = char.Parse(cmdArgs[2]);
                        password.Replace(charToChange, charToReplace);
                        break;
                    case "Includes":
                        string substring = cmdArgs[1];
                        if (password.ToString().Contains(substring))
                        {
                            Console.WriteLine("True");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("False");
                            continue;
                        }
                    case "End":
                        string endString = cmdArgs[1];
                        string substringLastChars = password.ToString().Substring(password.Length - endString.Length, endString.Length);
                        if (endString == substringLastChars)
                        {
                            Console.WriteLine("True");
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("False");
                            continue;
                        }
                    case "Uppercase":
                        string upper = password.ToString().ToUpper();
                        password.Clear();
                        password.Append(upper);
                        break;
                    case "FindIndex":
                        char currentChar = char.Parse(cmdArgs[1]);
                        int index = password.ToString().IndexOf(currentChar);
                        Console.WriteLine(index);
                        continue;
                    case "Cut":
                        int startIndex = int.Parse(cmdArgs[1]);
                        int length = int.Parse(cmdArgs[2]);
                        string subs = password.ToString().Substring(startIndex, length);
                        Console.WriteLine(subs);
                        continue;
                }

                Console.WriteLine(password);
            }
        }
    }
}
