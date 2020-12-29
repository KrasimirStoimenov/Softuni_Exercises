using System;

namespace _01._Smallest_of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int smallestNumber = GetSmallestNumber();

            Console.WriteLine(smallestNumber);
        }
        static int GetSmallestNumber()
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());

            int smallest = 0;
            if (first < second && first < third)
            {
                smallest = first;
            }
            else if (second < first && second < third)
            {
                smallest = second;
            }
            else
            {
                smallest = third;
            }
            return smallest;
        }
    }
}
