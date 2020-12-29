using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalogue catalogue = new Catalogue();
            ReadVechicles(catalogue);
            PrintOutput(catalogue);
        }

        static void PrintOutput(Catalogue catalogue)
        {
            if (catalogue.cars.Any())
            {
                Console.WriteLine("Cars:");
                catalogue.cars = catalogue.cars.OrderBy(n => n.Brand).ToList();
                foreach (var car in catalogue.cars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (catalogue.trucks.Any())
            {
                Console.WriteLine("Trucks:");
                catalogue.trucks = catalogue.trucks.OrderBy(n => n.Brand).ToList();
                foreach (var truck in catalogue.trucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }

        static void ReadVechicles(Catalogue catalogue)
        {
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split("/");
                if (cmdArgs[0] == "Car")
                {
                    Car car = new Car(cmdArgs[1], cmdArgs[2], int.Parse(cmdArgs[3]));
                    catalogue.cars.Add(car);
                }
                else if (cmdArgs[0] == "Truck")
                {
                    Truck truck = new Truck(cmdArgs[1], cmdArgs[2], int.Parse(cmdArgs[3]));
                    catalogue.trucks.Add(truck);
                }
            }
        }
    }
    //class Car
    //{
    //    //Define a class Car with the following properties: Brand, Model and Horse Power.

    //    public string Brand { get; set; }
    //    public string Model { get; set; }
    //    public int HorsePower { get; set; }

    //    public Car(string brand, string model, int hp)
    //    {
    //        this.Brand = brand;
    //        this.Model = model;
    //        this.HorsePower = hp;
    //    }
    //}
    //class Truck
    //{
    //    //Define a class Truck with the following properties: Brand, Model and Weight.
    //    public string Brand { get; set; }
    //    public string Model { get; set; }
    //    public int Weight { get; set; }

    //    public Truck(string brand, string model, int weight)
    //    {
    //        this.Brand = brand;
    //        this.Model = model;
    //        this.Weight = weight;
    //    }
    //}
    //class Catalogue
    //{
    //    public List<Car> cars = new List<Car>();
    //    public List<Truck> trucks = new List<Truck>();
    //}



}
