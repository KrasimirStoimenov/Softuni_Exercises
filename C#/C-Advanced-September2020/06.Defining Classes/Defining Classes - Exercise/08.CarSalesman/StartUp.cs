using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            FillEnginesList(engines);
            FillCarsList(cars, engines);
            PrintOutput(cars);

        }

        private static void PrintOutput(List<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }

        private static void FillCarsList(List<Car> cars, List<Engine> engines)
        {
            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                // "{model} {engine} {weight} {color}" 
                string[] carArgs = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string model = carArgs[0];
                string engineModel = carArgs[1];
                Engine engine = engines.Find(x => x.Model == engineModel);
                if (carArgs.Length == 3)
                {
                    int weight;
                    if (int.TryParse(carArgs[2], out weight))
                    {
                        Car car = new Car(model, engine, weight);
                        cars.Add(car);
                    }
                    else
                    {
                        string color = carArgs[2];
                        Car car = new Car(model, engine, color);
                        cars.Add(car);
                    }
                }
                else if (carArgs.Length == 4)
                {
                    int weight = int.Parse(carArgs[2]);
                    string color = carArgs[3];

                    Car car = new Car(model, engine, color, weight);
                    cars.Add(car);
                }
                else
                {
                    Car car = new Car(model, engine);
                    cars.Add(car);
                }
            }
        }

        private static void FillEnginesList(List<Engine> engines)
        {
            int enginesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < enginesCount; i++)
            {
                //"{model} {power} {displacement} {efficiency}"
                string[] enginesArgs = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string model = enginesArgs[0];
                int power = int.Parse(enginesArgs[1]);
                if (enginesArgs.Length == 3)
                {
                    int displacement;
                    if (int.TryParse(enginesArgs[2], out displacement))
                    {
                        Engine engine = new Engine(model, power, displacement);
                        engines.Add(engine);
                    }
                    else
                    {
                        string efficiency = enginesArgs[2];
                        Engine engine = new Engine(model, power, efficiency);
                        engines.Add(engine);
                    }
                }
                else if (enginesArgs.Length == 4)
                {
                    int displacement = int.Parse(enginesArgs[2]);
                    string efficiency = enginesArgs[3];

                    Engine engine = new Engine(model, power, displacement, efficiency);
                    engines.Add(engine);
                }
                else
                {
                    Engine engine = new Engine(model, power);
                    engines.Add(engine);
                }

            }
        }
    }
}
