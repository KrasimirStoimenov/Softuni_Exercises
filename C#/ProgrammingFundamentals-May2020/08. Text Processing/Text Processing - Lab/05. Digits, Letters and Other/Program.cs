using System;
using System.Text;

namespace _05._Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(InputChecker(input, 1));              //firstLineDigits
            sb.AppendLine(InputChecker(input, 2));              //secondLineCharacters
            sb.AppendLine(InputChecker(input, 3));              //ThirdLineSymbols

            Console.WriteLine(sb);

        }
        static string InputChecker(string input, int count)
        {
            StringBuilder result = new StringBuilder();

            foreach (var character in input)
            {
                if (count == 1)
                {
                    if (char.IsDigit(character))
                    {
                        result.Append(character);
                    }
                }
                else if (count == 2)
                {
                    if (char.IsLetter(character))
                    {
                        result.Append(character);
                    }
                }
                else if (count == 3)
                {
                    if (!char.IsDigit(character) && !char.IsLetter(character))
                    {
                        result.Append(character);
                    }
                }
            }

            return result.ToString();
        }
    }
}
