using System;
using System.Linq;

namespace _06._Reverse_Array_of_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split(new char[] { ' ' })
                .Reverse()
                .ToArray();

            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
