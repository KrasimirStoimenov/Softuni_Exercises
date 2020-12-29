using System;
using System.Numerics;
namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int highestSnowballSnow = 0;
            int highestSnowballTime = 0;
            int highestSnowballQuality = 0;
            BigInteger highestSnowballValue = 0;

            for (int i = 0; i < count; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                int snowball = (snowballSnow / snowballTime);
                BigInteger snowballValue = BigInteger.Pow(snowball, snowballQuality);
                if (snowballValue >= highestSnowballValue)
                {
                    highestSnowballSnow = snowballSnow;
                    highestSnowballTime = snowballTime;
                    highestSnowballQuality = snowballQuality;
                    highestSnowballValue = snowballValue;
                }
            }

            Console.WriteLine($"{highestSnowballSnow} : {highestSnowballTime} = {highestSnowballValue} ({highestSnowballQuality})");

        }
    }
}
