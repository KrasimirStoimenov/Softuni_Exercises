using System;

namespace _05._Word_in_Plural
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            char lastChar = word[word.Length - 1];
            string result = string.Empty;

            if (lastChar == 'y')
            {
                result = word.Remove(word.Length - 1);
                result += "ies";
            }
            else if (lastChar == 'o' || lastChar == 's' || lastChar == 'x' || lastChar == 'z' || lastChar == 'h')
            {
                result = word;
                result += "es";
            }
            else
            {
                result = word;
                result += "s";
            }
            Console.WriteLine(result);
        }
    }
}
