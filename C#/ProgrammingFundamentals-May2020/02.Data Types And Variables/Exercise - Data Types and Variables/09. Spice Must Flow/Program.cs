using System;

namespace _09._Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            uint startingYield = uint.Parse(Console.ReadLine());
            uint yieldGathered = 0;
            int days = 0;

            while (true)
            {
                if (startingYield < 100)
                {
                    break;
                }
                days++;
                yieldGathered += (startingYield - 26);
                startingYield -= 10;
            }
            if (yieldGathered >= 26)
            {
                yieldGathered -= 26;
            }

            Console.WriteLine(days);
            Console.WriteLine(yieldGathered);
        }
    }
}
