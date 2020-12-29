using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Treasure_Finder
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] keys = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            List<string> encryptedMessages = GetEncryptedMessages(keys);

            List<string> decryptedMessages = GetDecryptedMessages(encryptedMessages);

            PrintOutput(decryptedMessages);
        }

        static void PrintOutput(List<string> decryptedMessages)
        {
            foreach (var message in decryptedMessages)
            {
                string[] splittedProductAndCoordination = message.Split();
                Console.WriteLine($"Found {splittedProductAndCoordination[0]} at {splittedProductAndCoordination[1]}");
            }
        }

        static List<string> GetDecryptedMessages(List<string> encryptedMessages)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < encryptedMessages.Count; i++)
            {
                string resultString = string.Empty;
                int productStartIndex = encryptedMessages[i].IndexOf('&');
                int productEndIndex = encryptedMessages[i].LastIndexOf('&');
                int difference = productEndIndex - productStartIndex;
                resultString += encryptedMessages[i].Substring(productStartIndex + 1, difference - 1) + " ";

                int coordinationStartIndex = encryptedMessages[i].IndexOf('<');
                int coordinationEndIndex = encryptedMessages[i].IndexOf('>');
                int differenceCoordination = coordinationEndIndex - coordinationStartIndex;
                resultString += encryptedMessages[i].Substring(coordinationStartIndex + 1, differenceCoordination - 1);

                result.Add(resultString);
            }
            return result;
        }

        static List<string> GetEncryptedMessages(int[] keys)
        {
            List<string> result = new List<string>();

            int keyLength = keys.Length;

            string command;
            while ((command = Console.ReadLine()) != "find")
            {
                int counter = 0;
                string message = string.Empty;

                for (int i = 0; i < command.Length; i++)
                {
                    char currentChar = command[i];
                    int charAsInt = currentChar - keys[counter];
                    char chasAsChar = (char)charAsInt;
                    message += chasAsChar;
                    counter++;
                    if (counter == keyLength)
                    {
                        counter = 0;
                    }
                }

                result.Add(message);
            }

            return result;
        }
    }
}
