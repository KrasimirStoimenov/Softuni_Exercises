using System;

namespace _07._String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int strength = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    strength += input[i + 1] - '0';
                    continue;
                }
                else if (strength > 0)
                {
                    input = input.Remove(i,1);
                    strength--;
                    i--;
                }
            }

            Console.WriteLine(input);
        }
    }
}
