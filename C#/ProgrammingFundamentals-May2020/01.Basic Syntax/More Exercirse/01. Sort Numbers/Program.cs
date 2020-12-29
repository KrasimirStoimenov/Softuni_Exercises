using System;
using System.Linq;
namespace _01._Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int[] arr = new int[] { firstNum, secondNum, thirdNum };

            arr = arr.OrderByDescending(x => x).ToArray();

            Console.WriteLine(string.Join("\n",arr));

        }
    }
}
