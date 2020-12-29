using System;
using System.Linq;

namespace _04._Fold_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstArr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            int howMuchNumbersToTake = firstArr.Length / 4;

            int[] firstFold = new int[howMuchNumbersToTake];
            int[] secondFold = new int[howMuchNumbersToTake];
            int[] firstRow = new int[firstFold.Length + secondFold.Length];

            for (int i = 0; i < howMuchNumbersToTake; i++)
            {
                firstFold[i] = firstArr[i];
                secondFold[i] = firstArr[firstArr.Length - 1 - i];
            }

            firstFold = firstFold.Reverse().ToArray();

            for (int i = 0; i < firstFold.Length; i++)
            {
                firstRow[i] = firstFold[i];
                firstRow[i + howMuchNumbersToTake] = secondFold[i];
            }

            int[] secondRow = firstArr.Skip(howMuchNumbersToTake)
                .Take(firstArr.Length - 2 * howMuchNumbersToTake)
                .ToArray();

            int[] result = new int[secondRow.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = firstRow[i] + secondRow[i];
            }

            Console.WriteLine(string.Join(' ', result));

        }
    }
}
