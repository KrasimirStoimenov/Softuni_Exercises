using System;

namespace _17._Print_Part_Of_ASCII_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int first = Math.Min(firstNum, secondNum);
            int second = Math.Max(firstNum, secondNum);

            for (int i = first; i <= second; i++)
            {
                char current = (char)(i);
                Console.Write(current+" ");
            }
        }
    }
}
