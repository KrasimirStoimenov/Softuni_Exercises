using System;
using System.Collections.Generic;

namespace _03._Speed_Racing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> carList = AddingCarsToList();

            Proccessing(carList);

            Console.WriteLine(string.Join(Environment.NewLine, carList));
        }

        static void Proccessing(List<Car> carList)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split();
                string carModel = cmdArgs[1];
                double distance = double.Parse(cmdArgs[2]);

                Car currentCar = carList.Find(x => x.Model == carModel);

                bool canTravelDistance = currentCar.CanTravelThatDistance(distance, currentCar);
                if (canTravelDistance)
                {
                    currentCar.TraveledDistance += distance;
                    currentCar.FuelAmount -= distance * currentCar.FuelConsumption;
                }
                else
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }


            }
        }

        static List<Car> AddingCarsToList()
        {
            List<Car> list = new List<Car>();
            int carCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carCount; i++)
            {
                string[] carArgs = Console.ReadLine()
                    .Split();
                string model = carArgs[0];
                double fuel = double.Parse(carArgs[1]);
                double consumption = double.Parse(carArgs[2]);

                Car car = new Car(model, fuel, consumption, 0);
                list.Add(car);
            }

            return list;
        }
    }

    //class Car
    //{
    //    //model, fuel amount, fuel consumption per kilometer and traveled distance. 

    //    public string Model { get; set; }

    //    public double FuelAmount { get; set; }

    //    public double FuelConsumption { get; set; }

    //    public double TraveledDistance { get; set; }

    //    public Car(string model, double fuel, double consumption, double distance)
    //    {
    //        this.Model = model;
    //        this.FuelAmount = fuel;
    //        this.FuelConsumption = consumption;
    //        this.TraveledDistance = distance;

    //    }

    //    public bool CanTravelThatDistance(double distance, Car car)
    //    {
    //        double fuelNeeded = distance * car.FuelConsumption;
    //        if (fuelNeeded <= car.FuelAmount)
    //        {
    //            return true;
    //        }

    //        return false;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{this.Model} {this.FuelAmount:F2} {this.TraveledDistance}";
    //    }
    //}

}
