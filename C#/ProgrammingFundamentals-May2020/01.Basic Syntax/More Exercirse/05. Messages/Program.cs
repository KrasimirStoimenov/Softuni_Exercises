using System;

namespace _05._Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string output = string.Empty;

            for (int i = 0; i < num; i++)
            {
                string number = Console.ReadLine();
                int mainDigit = number[0] - '0';
                int offset = (mainDigit - 2) * 3;
                if (mainDigit == 0)
                {
                    output += " ";
                    continue;
                }
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset++;
                }
                int index = offset + number.Length - 1;
                output += (char)(index + 97);

            }

            Console.WriteLine(output);
        }
    }
}
