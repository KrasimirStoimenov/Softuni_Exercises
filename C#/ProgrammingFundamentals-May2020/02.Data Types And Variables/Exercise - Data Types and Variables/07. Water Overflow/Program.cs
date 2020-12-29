using System;

namespace _07._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int cappacity = 255;

            for (int i = 0; i < count; i++)
            {
                int water = int.Parse(Console.ReadLine());
                if (cappacity >= water)
                {
                    cappacity -= water;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(255 - cappacity);
        }
    }
}
