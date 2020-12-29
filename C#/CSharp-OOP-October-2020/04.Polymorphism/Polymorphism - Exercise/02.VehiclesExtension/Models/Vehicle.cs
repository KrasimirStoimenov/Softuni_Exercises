using System;

using _02.VehiclesExtension.Models.Contracts;

namespace _02.VehiclesExtension.Models
{
    public abstract class Vehicle : IDrivable, IRefuelable
    {
        private double tankCapacity;
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }
        public double FuelQuantity { get; protected set; }
        public double FuelConsumption { get; protected set; }
        public double TankCapacity
        {
            get
            {
                return this.tankCapacity;
            }
            private set
            {
                if (this.FuelQuantity > value)
                {
                    this.FuelQuantity = 0;
                }

                this.tankCapacity = value;


            }
        }
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
            double tankCapacityCheck = this.FuelQuantity + liters;
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (this.TankCapacity < tankCapacityCheck)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            this.FuelQuantity += liters;
        }
    }


}
