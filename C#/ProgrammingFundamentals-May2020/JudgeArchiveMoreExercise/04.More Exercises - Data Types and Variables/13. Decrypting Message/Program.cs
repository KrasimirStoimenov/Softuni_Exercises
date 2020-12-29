using System;

namespace _13._Decrypting_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int lines = int.Parse(Console.ReadLine());
            string result = string.Empty;

            for (int i = 0; i < lines; i++)
            {
                char current = char.Parse(Console.ReadLine());
                int resultAsInt = current + count;
                result += (char)resultAsInt;
            }
            Console.WriteLine(result);
        }
    }
}
