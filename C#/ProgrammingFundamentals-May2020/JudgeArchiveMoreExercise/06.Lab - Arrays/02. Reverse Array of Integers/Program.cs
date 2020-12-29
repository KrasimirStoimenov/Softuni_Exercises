using System;
using System.Linq;

namespace _02._Reverse_Array_of_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int countNumbers = int.Parse(Console.ReadLine());

            int[] numbers = new int[countNumbers];

            for (int i = 0; i < countNumbers; i++)
            {
                int currentNumber = int.Parse(Console.ReadLine());
                numbers[i] = currentNumber;
            }
            Console.WriteLine(string.Join(" ", numbers.Reverse()));
        }
    }
}
