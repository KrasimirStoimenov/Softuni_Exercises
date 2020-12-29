using System;

namespace _05._Decrypting_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int count = int.Parse(Console.ReadLine());
            string result = string.Empty;

            for (int i = 0; i < count; i++)
            {
                char character = char.Parse(Console.ReadLine());
                int currentCharAsInt = character + key;
                result += (char)currentCharAsInt;
            }

            Console.WriteLine(result);
        }
    }
}
