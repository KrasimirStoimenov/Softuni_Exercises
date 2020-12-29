using System;

namespace _05._Add_and_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            int sum = GetSumFromFirstAndSecondNumbers(firstNumber, secondNumber);
            int finalResult = GetFinalResult(sum, thirdNumber);

            Console.WriteLine(finalResult);
        }
        static int GetSumFromFirstAndSecondNumbers(int first, int second)
        {
            return first + second;
        }
        static int GetFinalResult(int sum, int thirdNum)
        {
            return sum - thirdNum;
        }

    }
}
