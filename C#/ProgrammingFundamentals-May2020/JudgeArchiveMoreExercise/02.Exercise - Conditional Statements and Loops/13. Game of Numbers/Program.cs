using System;

namespace _13._Game_of_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int combinationCounter = 0;

            for (int n1 = firstNumber; n1 <= secondNumber; n1++)
            {
                for (int n2 = firstNumber; n2 <= secondNumber; n2++)
                {
                    combinationCounter++;
                    if (n1 + n2 == magicNumber)
                    {
                        Console.WriteLine($"Number found! {n2} + {n1} = {magicNumber}");
                        return;
                    }
                }
            }
            Console.WriteLine($"{combinationCounter} combinations - neither equals {magicNumber}");
        }
    }
}
