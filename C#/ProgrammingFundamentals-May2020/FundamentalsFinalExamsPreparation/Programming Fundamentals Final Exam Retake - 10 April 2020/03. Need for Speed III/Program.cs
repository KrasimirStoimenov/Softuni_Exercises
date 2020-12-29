using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            FillingCarList(cars);
            ManipulatingCars(cars);
            PrintOutput(cars);
        }

        static void PrintOutput(List<Car> cars)
        {
            foreach (Car car in cars.OrderByDescending(m => m.Mileage)
                .ThenBy(n => n.CarName))
            {
                Console.WriteLine($"{car.CarName} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }

        static void ManipulatingCars(List<Car> cars)
        {
            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] cmdArgs = command.Split(" : ");
                string action = cmdArgs[0];
                string car = cmdArgs[1];
                Car currentCar = cars.Find(x => x.CarName == car);
                switch (action)
                {
                    case "Drive":
                        DriveManipulation(cars, cmdArgs, currentCar);
                        break;
                    case "Refuel":
                        RefuelManipulation(cars, cmdArgs, currentCar);
                        break;
                    case "Revert":
                        RevertManipulation(cars, cmdArgs, currentCar);
                        break;
                }
            }
        }

        static void RevertManipulation(List<Car> cars, string[] cmdArgs, Car currentCar)
        {
            int kilometers = int.Parse(cmdArgs[2]);
            if (currentCar.Mileage - kilometers > 10000)
            {
                currentCar.Mileage -= kilometers;
                Console.WriteLine($"{currentCar.CarName} mileage decreased by {kilometers} kilometers");
            }
            else
            {
                currentCar.Mileage = 10000;
            }

        }

        static void RefuelManipulation(List<Car> cars, string[] cmdArgs, Car currentCar)
        {
            int fuel = int.Parse(cmdArgs[2]);
            int totalFuel = currentCar.Fuel + fuel;
            if (totalFuel > 75)
            {
                Console.WriteLine($"{currentCar.CarName} refueled with {75 - currentCar.Fuel} liters");
                currentCar.Fuel = 75;
            }
            else
            {
                currentCar.Fuel = totalFuel;
                Console.WriteLine($"{currentCar.CarName} refueled with {fuel} liters");
            }
        }

        static void DriveManipulation(List<Car> cars, string[] cmdArgs, Car currentCar)
        {
            int distance = int.Parse(cmdArgs[2]);
            int fuel = int.Parse(cmdArgs[3]);
            if (fuel > currentCar.Fuel)
            {
                Console.WriteLine("Not enough fuel to make that ride");
            }
            else
            {
                currentCar.Mileage += distance;
                currentCar.Fuel -= fuel;
                Console.WriteLine($"{currentCar.CarName} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
            }
            if (currentCar.Mileage > 100000)
            {
                Console.WriteLine($"Time to sell the {currentCar.CarName}!");
                cars.Remove(currentCar);
            }
        }

        static void FillingCarList(List<Car> cars)
        {
            int carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                string[] args = Console.ReadLine()
                    .Split("|");
                string carName = args[0];
                int mileage = int.Parse(args[1]);
                int fuel = int.Parse(args[2]);

                Car car = new Car(carName, mileage, fuel);
                cars.Add(car);
            }
        }
    }
    //class Car
    //{
    //    //{car}|{mileage}|{fuel}

    //    public string CarName { get; set; }
    //    public int Mileage { get; set; }

    //    public int Fuel { get; set; }

    //    public Car(string carName, int mileage, int fuel)
    //    {
    //        this.CarName = carName;
    //        this.Mileage = mileage;
    //        this.Fuel = fuel;
    //    }
    //}

}
