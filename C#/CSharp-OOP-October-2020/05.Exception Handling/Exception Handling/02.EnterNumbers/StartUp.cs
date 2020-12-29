using System;

namespace _02.EnterNumbers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ReadNumber(1, 100);
        }

        public static void ReadNumber(int start, int end)
        {
            int numberCount = 10;
            while (true)
            {
                try
                {
                    int previousNumber = 1;
                    for (int i = 0; i < numberCount; i++)
                    {
                        Console.Write($"Number should be bigger than {previousNumber}: ");
                        int currentNumber = int.Parse(Console.ReadLine());
                        bool isValid = currentNumber > previousNumber && currentNumber < 100;
                        if (!isValid)
                        {
                            throw new InvalidOperationException("Number should be between [1 ... 100]");
                        }
                        previousNumber = currentNumber;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

                break;
            }
        }
    }
}
