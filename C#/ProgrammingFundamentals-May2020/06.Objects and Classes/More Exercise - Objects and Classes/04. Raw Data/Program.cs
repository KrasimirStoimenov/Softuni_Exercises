using System;
using System.Collections.Generic;

namespace _04._Raw_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> carList = new List<Car>();

            AddCarsToList(carList);
            PrintOutput(carList);
        }

        static void PrintOutput(List<Car> carList)
        {
            string command = Console.ReadLine();
            foreach (var car in carList)
            {
                if (command == "fragile")
                {
                    if (car.Cargo.Type == command && car.Cargo.Weight < 1000)
                    {
                        Console.WriteLine(car.Model);
                    }

                }
                else
                {
                    if (car.Cargo.Type == command && car.Engine.Power > 250)
                    {
                        Console.WriteLine(car.Model);
                    }

                }
            }
        }

        static void AddCarsToList(List<Car> carList)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] carArgs = Console.ReadLine().Split();
                string model = carArgs[0];
                int engineSpeed = int.Parse(carArgs[1]);
                int enginePower = int.Parse(carArgs[2]);
                int cargoWeight = int.Parse(carArgs[3]);
                string cargoType = carArgs[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                Car car = new Car(model, engine, cargo);
                carList.Add(car);
            }
        }
    }
    //class Car
    //{
    //    public string Model { get; set; }

    //    public Engine Engine { get; set; }

    //    public Cargo Cargo { get; set; }

    //    public Car(string model, Engine engine, Cargo cargo)
    //    {
    //        this.Model = model;
    //        this.Engine = engine;
    //        this.Cargo = cargo;
    //    }
    //}
    //class Cargo
    //{
    //    public int Weight { get; set; }

    //    public string Type { get; set; }

    //    public Cargo(int weight, string type)
    //    {
    //        this.Weight = weight;
    //        this.Type = type;
    //    }
    //}
    //class Engine
    //{
    //    public int Speed { get; set; }

    //    public int Power { get; set; }

    //    public Engine(int speed, int power)
    //    {
    //        this.Speed = speed;
    //        this.Power = power;
    //    }
    //}



}
