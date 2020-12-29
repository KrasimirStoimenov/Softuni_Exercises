using System;

namespace _03._Printing_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            TopSide(number);
            BottomSide(number);
        }
        static void TopSide(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                for (int counter = 1; counter <= i; counter++)
                {
                    Console.Write(counter + " ");
                }
                Console.WriteLine();
            }
        }
        static void BottomSide(int num)
        {
            for (int i = num - 1; i >= 1; i--)
            {
                for (int counter = 1; counter <= i; counter++)
                {
                    Console.Write(counter + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
