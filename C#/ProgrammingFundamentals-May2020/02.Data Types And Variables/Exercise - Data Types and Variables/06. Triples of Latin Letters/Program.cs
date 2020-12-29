using System;

namespace _06._Triples_of_Latin_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (char firstChar = 'a'; firstChar < 'a' + num; firstChar++)
            {
                for (char secondChar = 'a'; secondChar < num + 'a'; secondChar++)
                {
                    for (char thirdChar = 'a'; thirdChar < num + 'a'; thirdChar++)
                    {
                        string result = firstChar.ToString() + secondChar.ToString() + thirdChar.ToString();
                        Console.WriteLine(result);
                    }
                }
            }
        }
    }
}
