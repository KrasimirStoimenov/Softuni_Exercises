using System;

namespace _04._Draw_a_Filled_Square
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintHeaderAndBottomRow(n);
            PrintBody(n);
            PrintHeaderAndBottomRow(n);
        }
        static void PrintHeaderAndBottomRow(int n)
        {
            Console.WriteLine(new string('-', n * 2));
        }
        static void PrintBody(int n)
        {
            for (int i = 0; i < n-2; i++)
            {
                Console.Write("-");
                for (int j = 1; j < n; j++)
                {
                    Console.Write("\\/");
                }
                Console.WriteLine("-");
            }

        }
    }
}
