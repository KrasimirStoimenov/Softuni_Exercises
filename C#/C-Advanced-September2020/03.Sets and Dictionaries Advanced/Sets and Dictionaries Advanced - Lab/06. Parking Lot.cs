using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();

            Proccessing(cars);
            PrintOutput(cars);

        }

        static void PrintOutput(HashSet<string> cars)
        {
            if (cars.Count > 0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }

        static void Proccessing(HashSet<string> cars)
        {
            string car;
            while ((car = Console.ReadLine()) != "END")
            {
                string currentCar = car.Substring(car.Length - 8);
                if (car.StartsWith("IN"))
                {
                    cars.Add(currentCar);
                }
                else if (car.StartsWith("OUT"))
                {
                    cars.Remove(currentCar);
                }
            }
        }
    }
}
