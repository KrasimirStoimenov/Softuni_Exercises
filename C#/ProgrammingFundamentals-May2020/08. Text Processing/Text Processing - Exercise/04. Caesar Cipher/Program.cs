using System;
using System.Text;

namespace _04._Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            foreach (var character in text)
            {
                int encryptingChar = character + 3;
                char encryptedChar = (char)encryptingChar;
                sb.Append(encryptedChar);
            }

            Console.WriteLine(sb);
        }
    }
}
