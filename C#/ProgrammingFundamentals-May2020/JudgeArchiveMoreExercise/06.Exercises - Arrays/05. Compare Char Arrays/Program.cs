using System;
using System.Linq;

namespace _05._Compare_Char_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] firstArr = Console.ReadLine()
                .Split()
                .Select(char.Parse)
                .ToArray();
            char[] secondArr = Console.ReadLine()
                .Split()
                .Select(char.Parse)
                .ToArray();
            int count = Math.Min(firstArr.Length, secondArr.Length);
            bool firstArrToPrintFirst = false;
            for (int i = 0; i < count; i++)
            {
                if (firstArr[i] == secondArr[i])
                {
                    if (firstArr.Length < secondArr.Length)
                    {
                        firstArrToPrintFirst = true;
                    }
                    else
                    {
                        firstArrToPrintFirst = false;
                    }
                    continue;
                }
                else if (firstArr[i] < secondArr[i])
                {
                    firstArrToPrintFirst = true;
                    break;
                }
                else if (secondArr[i] < firstArr[i])
                {
                    break;
                }
            }

            if (firstArrToPrintFirst)
            {
                Console.WriteLine(string.Join("", firstArr));
                Console.WriteLine(string.Join("", secondArr));
            }
            else
            {
                Console.WriteLine(string.Join("", secondArr));
                Console.WriteLine(string.Join("", firstArr));
            }
        }
    }
}
