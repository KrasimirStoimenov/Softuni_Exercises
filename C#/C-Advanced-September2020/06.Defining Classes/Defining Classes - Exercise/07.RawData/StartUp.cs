using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            AddCars(cars);
            PrintOutput(cars);
        }

        private static void PrintOutput(List<Car> cars)
        {
            string wantedOutput = Console.ReadLine();
            if (wantedOutput == "fragile")
            {
                cars.Where(type => type.Cargo.CargoType == wantedOutput)
                    .Where(x => x.Tires.Any(x => x.Pressure < 1))
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));

            }
            else if (wantedOutput == "flamable")
            {
                cars.Where(type => type.Cargo.CargoType == wantedOutput)
                    .Where(enginePower => enginePower.Engine.EnginePower > 250)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }
        }

        private static void AddCars(List<Car> cars)
        {
            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                /*"{model} {engineSpeed} {enginePower} {cargoWeight} {cargoType} 
                {tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} 
                {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"*/
                string[] carArgs = Console.ReadLine()
                    .Split(" ")
                    .ToArray();
                string model = carArgs[0];

                Engine engine = GetEngine(carArgs);
                Cargo cargo = GetCargo(carArgs);
                Tire[] tires = GetTires(carArgs);

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);

            }
        }

        private static Engine GetEngine(string[] carArgs)
        {
            int engineSpeed = int.Parse(carArgs[1]);
            int enginePower = int.Parse(carArgs[2]);
            Engine engine = new Engine(engineSpeed, enginePower);
            return engine;
        }
        private static Cargo GetCargo(string[] carArgs)
        {
            int cargoWeight = int.Parse(carArgs[3]);
            string cargoType = carArgs[4];
            Cargo cargo = new Cargo(cargoType, cargoWeight);
            return cargo;
        }

        private static Tire[] GetTires(string[] carArgs)
        {
            Tire[] tires = new Tire[4];
            tires[0] = FillTire(tires, double.Parse(carArgs[5]), int.Parse(carArgs[6]));
            tires[1] = FillTire(tires, double.Parse(carArgs[7]), int.Parse(carArgs[8]));
            tires[2] = FillTire(tires, double.Parse(carArgs[9]), int.Parse(carArgs[10]));
            tires[3] = FillTire(tires, double.Parse(carArgs[11]), int.Parse(carArgs[12]));
            return tires;
        }


        private static Tire FillTire(Tire[] tires, double pressure, int year)
        {
            Tire tire = new Tire(year, pressure);

            return tire;
        }
    }
}
