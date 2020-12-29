using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01._Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string word = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < numbersList.Count; i++)
            {
                int index = SumDigits(numbersList, i);
                int currentIndexToAppend = index % word.Length;
                sb.Append(word[currentIndexToAppend]);
                word = word.Remove(currentIndexToAppend, 1);
            }
            Console.WriteLine(sb);
        }

        static int SumDigits(List<int> numbers, int i)
        {
            int sum = 0;
            while (numbers[i] != 0)
            {
                sum += numbers[i] % 10;
                numbers[i] /= 10;
            }
            return sum;
        }
    }
}
