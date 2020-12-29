using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            int passedCars = 0;

            bool hasCrashed = false;
            int indexCrashed = -1;
            string carCrashed = string.Empty;

            string car;
            while ((car = Console.ReadLine()) != "END")
            {
                if (car == "green")
                {
                    int currentGreenLight = greenLight;
                    while (currentGreenLight > 0 && cars.Any())
                    {
                        string currentCar = cars.Dequeue();
                        currentGreenLight -= currentCar.Length;
                        if (currentGreenLight < 0)
                        {
                            if (currentGreenLight + freeWindow<0)
                            {
                                indexCrashed = Math.Abs(currentGreenLight+freeWindow);
                                carCrashed = currentCar;
                                hasCrashed = true;
                                break;
                            }
                        }
                        passedCars++;
                    }
                }
                else
                {
                    cars.Enqueue(car);
                }

                if (hasCrashed)
                {
                    break;
                }
            }
            if (hasCrashed)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{carCrashed} was hit at {carCrashed[carCrashed.Length-indexCrashed]}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCars} total cars passed the crossroads.");
            }
        }
    }
}
