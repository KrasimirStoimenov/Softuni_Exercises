using System;

namespace _06._Catch_the_Thief
{
    class Program
    {
        static void Main(string[] args)
        {
            string thiefIdNumeralType = Console.ReadLine();
            int countId = int.Parse(Console.ReadLine());
            long typeMaxValue = 0;
            switch (thiefIdNumeralType)
            {
                case "sbyte":
                    typeMaxValue = sbyte.MaxValue;
                    break;
                case "int":
                    typeMaxValue = int.MaxValue;
                    break;
                case "long":
                    typeMaxValue = long.MaxValue;
                    break;
            }

            long closestNumber = long.MinValue;

            for (int i = 0; i < countId; i++)
            {
                long ids = long.Parse(Console.ReadLine());

                if (closestNumber < ids && ids <= typeMaxValue)
                {
                    closestNumber = ids;
                }
            }
            Console.WriteLine(closestNumber);
        }
    }
}
