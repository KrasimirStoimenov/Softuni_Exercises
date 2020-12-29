using System;
using System.Linq;

namespace _01._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            int[] wagons = new int[count];

            for (int i = 0; i < count; i++)
            {
                int currentPeopleGoingInWagon = int.Parse(Console.ReadLine());
                wagons[i] = currentPeopleGoingInWagon;
            }

            Console.WriteLine(string.Join(' ', wagons));
            Console.WriteLine(wagons.Sum());
        }
    }
}
