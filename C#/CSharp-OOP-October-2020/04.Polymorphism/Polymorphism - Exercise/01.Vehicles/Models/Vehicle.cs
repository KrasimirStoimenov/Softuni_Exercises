using System;

using _01.Vehicles.Models.Contracts;

namespace _01.Vehicles.Models
{
    public abstract class Vehicle : IDrivable, IRefuelable
    {
        public Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; protected set; }
        public double FuelConsumption { get; protected set; }
        public string Drive(double kilometers)
        {
            double fuelNeeded = kilometers * this.FuelConsumption;
            if (this.FuelQuantity < fuelNeeded)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {kilometers} km";
        }

        public virtual void Refuel(double liters)
        {
            this.FuelQuantity += liters;
        }
    }


}
