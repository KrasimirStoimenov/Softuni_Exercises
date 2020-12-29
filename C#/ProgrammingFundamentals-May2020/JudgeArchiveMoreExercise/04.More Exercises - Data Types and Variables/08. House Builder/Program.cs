using System;

namespace _08._House_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFirst = Console.ReadLine();
            string inputSecond = Console.ReadLine();
            bool isFirstSbyte = sbyte.TryParse(inputFirst, out sbyte res);
            if (isFirstSbyte)
            {
                sbyte.TryParse(inputFirst, out sbyte resultSbyte);
                long.TryParse(inputSecond, out long resultInt2);
                Console.WriteLine(4 * resultSbyte + 10 * resultInt2);
            }
            else
            {
                sbyte.TryParse(inputSecond, out sbyte resultSbyte2);
                long.TryParse(inputFirst, out long resultInt);
                Console.WriteLine((4 * resultSbyte2) + (10 * resultInt));
            }
        }
    }
}
