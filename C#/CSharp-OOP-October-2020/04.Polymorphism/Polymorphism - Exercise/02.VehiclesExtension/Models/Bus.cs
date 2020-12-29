using System;

namespace _02.VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double AIR_CONDITION_INCREASED_FUEL = 1.40;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AIR_CONDITION_INCREASED_FUEL;
        }

        public string DriveEmpty(double kilometers)
        {
            double fuelNeeded = kilometers * (this.FuelConsumption - AIR_CONDITION_INCREASED_FUEL);
            if (this.FuelQuantity < fuelNeeded)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled {kilometers} km";
        }
    }
}
