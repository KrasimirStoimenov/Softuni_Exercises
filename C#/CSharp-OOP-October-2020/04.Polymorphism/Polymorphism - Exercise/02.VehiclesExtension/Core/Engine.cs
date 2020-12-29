using System;
using System.Linq;

using _02.VehiclesExtension.Models;
using _02.VehiclesExtension.Core.Contracts;

namespace _02.VehiclesExtension.Core
{
    public class Engine : IEngine
    {
        public Engine()
        {

        }
        public void Run()
        {
            string[] carArgs = GetVehicleArgs();
            Car car = (Car)GetVehicle(carArgs);
            string[] truckArgs = GetVehicleArgs();
            Truck truck = (Truck)GetVehicle(truckArgs);
            string[] busArgs = GetVehicleArgs();
            Bus bus = (Bus)GetVehicle(busArgs);

            ProcessWithCommands(car, truck, bus);
            PrintOutput(car, truck, bus);
        }

        private void PrintOutput(Car car, Truck truck, Bus bus)
        {
            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }

        private void ProcessWithCommands(Car car, Truck truck, Bus bus)
        {
            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(" ")
                    .ToArray();
                string type = cmdArgs[1];
                double distanceOrLitters = double.Parse(cmdArgs[2]);
                switch (cmdArgs[0])
                {
                    case "Drive":
                        DriveVehicle(car, truck, bus, type, distanceOrLitters);
                        break;
                    case "DriveEmpty":
                        try
                        {
                            Console.WriteLine(bus.DriveEmpty(distanceOrLitters));
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                        break;
                    case "Refuel":
                        RefuelVehicle(car, truck, bus, type, distanceOrLitters);
                        break;
                }
            }
        }

        private void RefuelVehicle(Car car, Truck truck, Bus bus, string type, double liters)
        {
            try
            {
                if (type == "Car")
                {
                    car.Refuel(liters);
                }
                else if (type == "Truck")
                {
                    truck.Refuel(liters);
                }
                else if (type == "Bus")
                {
                    bus.Refuel(liters);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private void DriveVehicle(Car car, Truck truck, Bus bus, string type, double distance)
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
                else if (type == "Bus")
                {
                    Console.WriteLine(bus.Drive(distance));
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
            double tankCapacity = double.Parse(typeArgs[3]);
            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }

            return vehicle;
        }
        private string[] GetVehicleArgs() => Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToArray();
    }
}
