using System;
using System.Linq;

namespace _06._Heists
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] priceForJewelsAndGold = ReadIntArray();

            int priceForJewel = priceForJewelsAndGold[0];
            int priceForGold = priceForJewelsAndGold[1];
            Proccessing(priceForJewel, priceForGold);
        }

        static void Proccessing(int priceForJewel, int priceForGold)
        {
            int income = 0;
            int expenses = 0;
            string command;
            while ((command = Console.ReadLine()) != "Jail Time")
            {
                string[] cmdArgs = command.Split();
                income += GetIncome(cmdArgs[0], priceForJewel, priceForGold);
                expenses += int.Parse(cmdArgs[1]);
            }

            PrintOutput(income, expenses);
        }

        static void PrintOutput(int income, int expenses)
        {
            if (income >= expenses)
            {
                Console.WriteLine($"Heists will continue. Total earnings: {income-expenses}.");
            }
            else
            {
                Console.WriteLine($"Have to find another job. Lost: {expenses-income}.");
            }
        }


        static int GetIncome(string word, int priceForJewel, int priceForGold)
        {
            int sum = 0;
            for (int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];
                if (currentChar == '%')
                {
                    sum += priceForJewel;
                }
                else if (currentChar == '$')
                {
                    sum += priceForGold;
                }
            }
            return sum;
        }

        static int[] ReadIntArray() => Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
    }
}
