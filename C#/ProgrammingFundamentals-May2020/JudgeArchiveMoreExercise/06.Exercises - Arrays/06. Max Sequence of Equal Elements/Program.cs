using System;
using System.Linq;

namespace _06._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int currentSequenceCount = 1;
            int bestSequenceCount = 1;
            int bestNumber = 0;

            for (int i = 0; i < initialArr.Length - 1; i++)
            {
                if (initialArr[i] == initialArr[i + 1])
                {
                    currentSequenceCount++;

                }
                else
                {
                    currentSequenceCount = 1;
                }

                if (currentSequenceCount > bestSequenceCount)
                {
                    bestSequenceCount = currentSequenceCount;
                    bestNumber = initialArr[i];
                }
            }

            for (int i = 0; i < bestSequenceCount; i++)
            {

                Console.Write(bestNumber+ " ");
            }
        }
    }
}
