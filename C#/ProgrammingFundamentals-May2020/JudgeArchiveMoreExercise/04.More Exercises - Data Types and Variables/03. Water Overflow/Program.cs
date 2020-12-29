using System;

namespace _03._Water_Overflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int tankSpace = 0;
            for (int i = 0; i < count; i++)
            {
                int quantityWater = int.Parse(Console.ReadLine());
                tankSpace += quantityWater;
                if (tankSpace > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    tankSpace -= quantityWater;
                }
            }
            Console.WriteLine(tankSpace);
        }
    }
}
