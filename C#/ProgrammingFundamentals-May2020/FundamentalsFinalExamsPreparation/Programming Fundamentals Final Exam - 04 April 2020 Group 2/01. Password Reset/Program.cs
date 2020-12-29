using System;
using System.Linq;
using System.Text;

namespace _01._Password_Reset
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPassword = Console.ReadLine();

            string newPasswordGenerate = inputPassword;
            string input;
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] inputArgs = input.Split(" ").ToArray();
                string command = inputArgs[0];
                switch (command)
                {
                    case "TakeOdd":
                        newPasswordGenerate = TakeOddIndexesCharacters(newPasswordGenerate);
                        break;
                    case "Cut":
                        newPasswordGenerate = CutFromPassword(newPasswordGenerate, inputArgs);
                        break;
                    case "Substitute":
                        if (newPasswordGenerate.Contains(inputArgs[1]))
                        {
                            newPasswordGenerate = SubstitutePassword(newPasswordGenerate, inputArgs);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                            continue;
                        }
                        break;
                }
                Console.WriteLine(newPasswordGenerate);
            }

            Console.WriteLine($"Your password is: {newPasswordGenerate}");
        }

        static string SubstitutePassword(string newPasswordGenerate, string[] inputArgs)
        {
            string substring = inputArgs[1];
            string substitute = inputArgs[2];

            while (newPasswordGenerate.Contains(substring))
            {
                newPasswordGenerate = newPasswordGenerate.Replace(substring, substitute);
            }

            return newPasswordGenerate;
        }

        static string CutFromPassword(string newPasswordGenerate, string[] inputArgs)
        {
            int index = int.Parse(inputArgs[1]);
            int length = int.Parse(inputArgs[2]);

            return newPasswordGenerate.Remove(index, length);
        }

        static string TakeOddIndexesCharacters(string inputPassword)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < inputPassword.Length; i ++)
            {
                if (i % 2 != 0)
                {
                    sb.Append(inputPassword[i]);
                }
            }

            return sb.ToString();
        }
    }
}
