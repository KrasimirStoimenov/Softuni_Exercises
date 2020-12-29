using System;
using System.Linq;

using _01.Vehicles.Models;
using _01.Vehicles.Core.Contracts;

namespace _01.Vehicles.Core
{
    public class Engine : IEngine
    {
        public Engine()
        {

        }
        public void Run()
        {
            string[] carArgs = GetVehicleArgs();
            Vehicle car = GetVehicle(carArgs);
            string[] truckArgs = GetVehicleArgs();
            Vehicle truck = GetVehicle(truckArgs);

            ProcessWithCommands(car, truck);
            PrintOutput(car, truck);
        }

        private void PrintOutput(Vehicle car, Vehicle truck)
        {
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
        }

        private void ProcessWithCommands(Vehicle car, Vehicle truck)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string type = cmdArgs[1];
                double distanceOrLitters = double.Parse(cmdArgs[2]);
                switch (cmdArgs[0])
                {
                    case "Drive":
                        DriveVehicle(car, truck, type, distanceOrLitters);
                        break;
                    case "Refuel":
                        RefuelVehicle(car, truck, type, distanceOrLitters);
                        break;
                }
            }
        }

        private void RefuelVehicle(Vehicle car, Vehicle truck, string type, double litters)
        {
            if (type == "Car")
            {
                car.Refuel(litters);
            }
            else if (type == "Truck")
            {
                truck.Refuel(litters);
            }
        }

        private void DriveVehicle(Vehicle car, Vehicle truck, string type, double distance)
        {
            try
            {
                if (type == "Car")
                {
                    Console.WriteLine(car.Drive(distance));
                }
                else if (type == "Truck")
                {
                    Console.WriteLine(truck.Drive(distance));
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private Vehicle GetVehicle(string[] typeArgs)
        {
            Vehicle vehicle = null;
            string type = typeArgs[0];
            double fuelQuantity = double.Parse(typeArgs[1]);
            double fuelConsumption = double.Parse(typeArgs[2]);
            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }

            return vehicle;
        }
        private string[] GetVehicleArgs() => Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
    }
}
