using System;
using System.Linq;

namespace _07._Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int maxSequence = 0;
            int number = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int currentNumber = arr[i];
                int counter = 1;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] != currentNumber)
                    {
                        break;
                    }
                    counter++;
                }

                if (counter > maxSequence)
                {
                    maxSequence = counter;
                    number = currentNumber;
                }
            }
            for (int i = 0; i < maxSequence; i++)
            {
                Console.Write(number +" ");
            }
        }
    }
}
