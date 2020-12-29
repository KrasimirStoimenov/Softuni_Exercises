using System;

namespace _07._NxN_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberToInt = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberToInt; i++)
            {
                for (int j = 0; j < numberToInt; j++)
                {
                    Console.Write(numberToInt + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
