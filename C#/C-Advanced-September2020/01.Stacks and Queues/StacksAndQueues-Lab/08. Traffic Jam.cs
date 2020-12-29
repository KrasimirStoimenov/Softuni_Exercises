using System;
using System.Collections.Generic;

namespace _08._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> cars = new Queue<string>();

            int carPasses = int.Parse(Console.ReadLine());
            int carPassedCounter = 0;

            string car;
            while ((car = Console.ReadLine()) != "end")
            {
                if (car == "green")
                {
                    for (int i = 0; i < carPasses; i++)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }

                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        carPassedCounter++;
                    }
                }
                else
                {
                    cars.Enqueue(car);
                }
            }

            Console.WriteLine($"{carPassedCounter} cars passed the crossroads.");
        }
    }
}
