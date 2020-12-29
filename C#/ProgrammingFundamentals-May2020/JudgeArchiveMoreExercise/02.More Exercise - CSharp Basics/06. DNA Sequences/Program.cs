using System;

namespace _06._DNA_Sequences
{
    class Program
    {
        static void Main(string[] args)
        {
            int magicNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    for (int k = 1; k <= 4; k++)
                    {
                        char firstChar=' ';
                        char secongChar=' ';
                        char thirdChar=' ';
                        if (i == 1)
                        {
                            firstChar = 'A';
                        }
                        else if (i == 2)
                        {
                            firstChar = 'C';
                        }
                        else if (i == 3)
                        {
                            firstChar = 'G';
                        }
                        else if (i == 4)
                        {
                            firstChar = 'T';
                        }

                        if (j == 1)
                        {
                            secongChar = 'A';
                        }
                        else if (j == 2)
                        {
                            secongChar = 'C';
                        }
                        else if (j == 3)
                        {
                            secongChar = 'G';
                        }
                        else if (j == 4)
                        {
                            secongChar = 'T';
                        }

                        if (k == 1)
                        {
                            thirdChar = 'A';
                        }
                        else if (k == 2)
                        {
                            thirdChar = 'C';
                        }
                        else if (k == 3)
                        {
                            thirdChar = 'G';
                        }
                        else if (k == 4)
                        {
                            thirdChar = 'T';
                        }

                        if (i + j + k >= magicNumber)
                        {
                            Console.Write($"O{firstChar}{secongChar}{thirdChar}O ");
                        }
                        else
                        {
                            Console.Write($"X{firstChar}{secongChar}{thirdChar}X ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
