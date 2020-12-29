using System;

namespace _01._Largest_Common_End
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine()
                .Split();
            string[] secondLine = Console.ReadLine()
                .Split();

            int lesserLength = Math.Min(firstLine.Length, secondLine.Length);
            int leftCounter = 0;
            int rightCounter = 0;
            for (int i = 0; i < lesserLength; i++)
            {
                if (firstLine[i] == secondLine[i])
                {
                    leftCounter++;
                }
                if (firstLine[firstLine.Length - 1 - i] == secondLine[secondLine.Length - 1 - i])
                {
                    rightCounter++;
                }

            }
            if (leftCounter > rightCounter)
            {
                Console.WriteLine(leftCounter);
            }
            else
            {
                Console.WriteLine(rightCounter);
            }

        }
    }
}
