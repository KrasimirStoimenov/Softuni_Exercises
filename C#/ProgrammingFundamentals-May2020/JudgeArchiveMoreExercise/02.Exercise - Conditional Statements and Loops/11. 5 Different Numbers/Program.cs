using System;

namespace _11._5_Different_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            if (secondNum - firstNum < 5)
            {
                Console.WriteLine("No");
            }

            for (int n1 = firstNum; n1 <= secondNum; n1++)
            {
                for (int n2 = n1 + 1; n2 <= secondNum; n2++)
                {
                    for (int n3 = n2 + 1; n3 <= secondNum; n3++)
                    {
                        for (int n4 = n3 + 1; n4 <= secondNum; n4++)
                        {
                            for (int n5 = n4 + 1; n5 <= secondNum; n5++)
                            {
                                //a ≤ n1 < n2 < n3 < n4 ≤ n5 ≤ b
                                if (firstNum <= n1 && n1 < n2 && n2 < n3 && n3 < n4 && n4 <= n5 && n5 <= secondNum)
                                {
                                    Console.WriteLine($"{n1} {n2} {n3} {n4} {n5}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
