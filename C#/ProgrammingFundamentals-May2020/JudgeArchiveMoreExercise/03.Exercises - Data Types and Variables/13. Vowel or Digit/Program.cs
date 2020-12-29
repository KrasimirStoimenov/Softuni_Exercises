using System;

namespace _13._Vowel_or_Digit
{
    class Program
    {
        static void Main(string[] args)
        {
            char input = char.Parse(Console.ReadLine());

            if (char.IsDigit(input))
            {
                Console.WriteLine("digit");
            }
            else
            {
                switch (input)
                {
                    case 'a':
                    case 'o':
                    case 'u':
                    case 'e':
                    case 'i':
                        Console.WriteLine("vowel");
                        break;
                    default:
                        Console.WriteLine("other");
                        break;
                }
            }

        }
    }
}
