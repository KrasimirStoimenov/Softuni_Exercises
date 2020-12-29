using System;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] cmdArgs = command.Split(":|:");

                switch (cmdArgs[0])
                {
                    case "InsertSpace":
                        int indexToInsert = int.Parse(cmdArgs[1]);
                        encryptedMessage = encryptedMessage.Insert(indexToInsert, " ");
                        break;
                    case "Reverse":
                        string word = cmdArgs[1];
                        if (encryptedMessage.Contains(word))
                        {
                            int indexOfWord = encryptedMessage.IndexOf(word);
                            string substringedWord = encryptedMessage.Substring(indexOfWord, word.Length);
                            encryptedMessage = encryptedMessage.Remove(indexOfWord, word.Length);
                            string wordToInsert = ReverseSubstringedWord(substringedWord);
                            encryptedMessage = encryptedMessage.Insert(encryptedMessage.Length, wordToInsert);
                        }
                        else
                        {
                            Console.WriteLine("error");
                            continue;
                        }
                        break;
                    case "ChangeAll":
                        string wordToChange = cmdArgs[1];
                        string newWord = cmdArgs[2];
                        int indexToChange = 0;
                        while (indexToChange > -1)
                        {
                            indexToChange = encryptedMessage.IndexOf(wordToChange);
                            encryptedMessage = encryptedMessage.Replace(wordToChange, newWord);
                        }
                        break;
                }

                Console.WriteLine(encryptedMessage);
            }

            Console.WriteLine($"You have a new text message: {encryptedMessage}");
        }

        static string ReverseSubstringedWord(string substringedWord)
        {
            string result = string.Empty;
            for (int i = substringedWord.Length - 1; i >= 0; i--)
            {
                result += substringedWord[i];
            }

            return result;
        }
    }
}
