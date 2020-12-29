using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Email_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputEmail = Console.ReadLine();
            Proccessing(inputEmail);
        }

        static void Proccessing(string inputEmail)
        {
            StringBuilder email = new StringBuilder(inputEmail);

            string command;
            while ((command = Console.ReadLine()) != "Complete")
            {
                if (command.Contains("Make Upper"))
                {
                    string makeUpper = email.ToString().ToUpper();
                    email.Clear();
                    email.Append(makeUpper);
                }
                else if (command.Contains("Make Lower"))
                {
                    string makeLower = email.ToString().ToLower();
                    email.Clear();
                    email.Append(makeLower);
                }
                else if (command.Contains("GetDomain"))
                {
                    string[] cmdArgs = command.Split(" ");
                    int count = int.Parse(cmdArgs[1]);
                    char[] domain = email.ToString().TakeLast(count).ToArray();
                    Console.WriteLine(string.Join("", domain));
                    continue;
                }
                else if (command.Contains("GetUsername"))
                {
                    if (email.ToString().Contains("@"))
                    {
                        int index = email.ToString().IndexOf("@");
                        string substringUsername = email.ToString().Substring(0, index);
                        Console.WriteLine(substringUsername);
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                        continue;
                    }
                }
                else if (command.Contains("Replace"))
                {
                    string[] cmdArgs = command.Split(" ");
                    char charToReplace = char.Parse(cmdArgs[1]);
                    email.Replace(charToReplace, '-');
                }
                else if (command.Contains("Encrypt"))
                {
                    List<int> asciiValues = new List<int>();
                    foreach (var character in email.ToString())
                    {
                        asciiValues.Add(character);
                    }
                    Console.WriteLine(string.Join(" ", asciiValues));
                    continue;
                }

                Console.WriteLine(email);
            }
        }
    }
}
