using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            ReadCars(cars);
            DriveCars(cars);
            PrintCars(cars);
        }

        private static void PrintCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.TravelledDistance}");
            }
        }

        private static void DriveCars(List<Car> cars)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(" ").ToArray();
                string model = cmdArgs[1];
                double distance = double.Parse(cmdArgs[2]);

                Car car = cars.Find(m => m.Model == model);
                car.Drive(distance);

            }
        }

        private static void ReadCars(List<Car> cars)
        {
            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                //"{model} {fuelAmount} {fuelConsumptionFor1km}"
                string[] carArgs = Console.ReadLine()
                    .Split(" ")
                    .ToArray();

                string model = carArgs[0];
                double fuelAmount = double.Parse(carArgs[1]);
                double fuelConsumption = double.Parse(carArgs[2]);

                Car car = new Car(model, fuelAmount, fuelConsumption);
                cars.Add(car);
            }
        }
    }
}
