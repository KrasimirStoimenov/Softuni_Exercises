using System;

namespace _12._Refactor_Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            for (int i = 1; i <= input; i++)
            {
                bool specialNumber = false;
                int sum = 0;
                int currentNum = i;
                while (currentNum > 0)
                {
                    sum += currentNum % 10;
                    currentNum = currentNum / 10;
                }

                if ((sum == 5) || (sum == 7) || (sum == 11))
                {
                    specialNumber = true;
                }

                Console.WriteLine("{0} -> {1}", i, specialNumber);

            }
        }
    }
}
