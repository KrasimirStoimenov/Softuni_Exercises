using System;

namespace _12._Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            string biggestKeg = string.Empty;
            double biggestKegVolume = 0;

            for (int i = 0; i < count; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                double volume = Math.PI * (radius * radius) * height;

                if (volume > biggestKegVolume)
                {
                    biggestKeg = model;
                    biggestKegVolume = volume;
                }
            }

            Console.WriteLine(biggestKeg);
        }
    }
}
