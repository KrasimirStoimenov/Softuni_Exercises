using System;

namespace _12._Test_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int maxSum = int.Parse(Console.ReadLine());

            int sum = 0;
            int combinationCounter = 0;
            bool needToStopProgram = false;

            for (int n1 = firstNumber; n1 >= 1; n1--)
            {
                for (int n2 = 1; n2 <= secondNumber; n2++)
                {
                    combinationCounter++;
                    sum += (n1 * n2) * 3;
                    if (sum >= maxSum)
                    {
                        needToStopProgram = true;
                        break;
                    }
                }
                if (needToStopProgram)
                {
                    break;
                }
            }

            if (needToStopProgram)
            {
                Console.WriteLine($"{combinationCounter} combinations");
                Console.WriteLine($"Sum: {sum} >= {maxSum}");
            }
            else
            {
                Console.WriteLine($"{combinationCounter} combinations");
                Console.WriteLine($"Sum: {sum}");
            }
        }
    }
}
