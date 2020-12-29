using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tire[]> tiresList = new List<Tire[]>();
            List<Engine> enginesList = new List<Engine>();
            List<Car> carsList = new List<Car>();

            FillTiresList(tiresList);
            FillEnginesList(enginesList);
            FillCarsList(carsList, enginesList, tiresList);
            DriveAllCars(carsList);
        }

        public static void DriveAllCars(List<Car> carsList)
        {
            List<Car> specialCar = carsList.Where(y => y.Year >= 2017)
                .Where(hp => hp.Engine.HorsePower > 330)
                .Where(s => s.Tires.Sum(p => p.Pressure) >= 9 && s.Tires.Sum(p => p.Pressure) <= 10)
                .ToList();

            foreach (var car in specialCar)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
            }

        }

        public static double GetTirePressureSum(Tire[] tires)
        {
            double sumPressure = 0;
            foreach (var tire in tires)
            {
                sumPressure += tire.Pressure;
            }

            return sumPressure;
        }

        public static void FillCarsList(List<Car> carsList, List<Engine> enginesList, List<Tire[]> tiresList)
        {
            string command;
            while ((command = Console.ReadLine()) != "Show special")
            {
                //{make} {model} {year} {fuelQuantity} {fuelConsumption} {engineIndex} {tiresIndex}
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string make = cmdArgs[0];
                string model = cmdArgs[1];
                int year = int.Parse(cmdArgs[2]);
                double fuelQuantity = double.Parse(cmdArgs[3]);
                double fuelConsumption = double.Parse(cmdArgs[4]);
                int engineIndex = int.Parse(cmdArgs[5]);
                int tiresIndex = int.Parse(cmdArgs[6]);

                Engine engineWanted = enginesList[engineIndex];
                Tire[] tiresWanted = tiresList[tiresIndex];

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engineWanted, tiresWanted);
                carsList.Add(car);
            }
        }

        public static void FillEnginesList(List<Engine> enginesList)
        {
            string command;
            while ((command = Console.ReadLine()) != "Engines done")
            {
                //{horsePower} {cubicCapacity} 
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int horsePower = int.Parse(cmdArgs[0]);
                double cubicCapacity = double.Parse(cmdArgs[1]);
                Engine engine = new Engine(horsePower, cubicCapacity);
                enginesList.Add(engine);
            }
        }

        public static void FillTiresList(List<Tire[]> tiresList)
        {
            string command;
            while ((command = Console.ReadLine()) != "No more tires")
            {
                //{year} {pressure}
                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Tire[] tires = new Tire[4];
                tires[0] = new Tire(int.Parse(cmdArgs[0]), double.Parse(cmdArgs[1]));
                tires[1] = new Tire(int.Parse(cmdArgs[2]), double.Parse(cmdArgs[3]));
                tires[2] = new Tire(int.Parse(cmdArgs[4]), double.Parse(cmdArgs[5]));
                tires[3] = new Tire(int.Parse(cmdArgs[6]), double.Parse(cmdArgs[7]));

                tiresList.Add(tires);
            }
        }

    }
}

