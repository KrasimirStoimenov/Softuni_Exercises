using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Speed_Racing
{
    class Car
    {
        //model, fuel amount, fuel consumption per kilometer and traveled distance. 

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumption { get; set; }

        public double TraveledDistance { get; set; }

        public Car(string model, double fuel, double consumption, double distance)
        {
            this.Model = model;
            this.FuelAmount = fuel;
            this.FuelConsumption = consumption;
            this.TraveledDistance = distance;

        }

        public bool CanTravelThatDistance(double distance, Car car)
        {
            double fuelNeeded = distance * car.FuelConsumption;
            if (fuelNeeded <= car.FuelAmount)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.TraveledDistance}";
        }
    }
}
