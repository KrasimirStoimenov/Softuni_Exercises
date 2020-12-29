using System;

namespace _14._Magic_Letter
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char secondLetter = char.Parse(Console.ReadLine());
            char forbiddenLetter = char.Parse(Console.ReadLine());

            for (int firstChar = firstLetter; firstChar <= secondLetter; firstChar++)
            {
                for (int secondChar = firstLetter; secondChar <= secondLetter; secondChar++)
                {
                    for (int thirdChar = firstLetter; thirdChar <= secondLetter; thirdChar++)
                    {
                        if (!(firstChar == forbiddenLetter || secondChar == forbiddenLetter || thirdChar == forbiddenLetter))
                        {
                            Console.Write($"{(char)firstChar}{(char)secondChar}{(char)thirdChar} ");
                        }
                    }
                }
            }
        }
    }
}
