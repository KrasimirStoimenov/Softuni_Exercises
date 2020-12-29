using System;

namespace _01.SquareRoot
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number <= 0)
                {
                    throw new ArgumentOutOfRangeException("Number should be positive");
                }
                int squareRoot = number * number;
                Console.WriteLine(squareRoot);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Number");
            }
            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
