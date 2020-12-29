using System;

namespace _03._Megapixels
{
    class Program
    {
        static void Main(string[] args)
        {
            long width = long.Parse(Console.ReadLine());
            long length = long.Parse(Console.ReadLine());

            decimal megapixel = (decimal)width * length / 1000000;

            Console.WriteLine($"{width}x{length} => {Math.Round(megapixel,1)}MP");
        }
    }
}
