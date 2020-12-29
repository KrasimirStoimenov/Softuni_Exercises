using System;
using System.Linq;
namespace _02._Print_Numbers_in_Reverse_Order
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
