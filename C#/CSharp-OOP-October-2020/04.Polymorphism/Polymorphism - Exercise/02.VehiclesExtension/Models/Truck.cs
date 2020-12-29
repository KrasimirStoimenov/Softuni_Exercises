using System;

namespace _02.VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double AIR_CONDITION_INCREASED_CONSUMPTION = 1.6;
        private const double TANK_REFUEL = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AIR_CONDITION_INCREASED_CONSUMPTION;
        }

        public override void Refuel(double liters)
        {
            double tankCapacityCheck = this.FuelQuantity + liters*TANK_REFUEL;
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (this.TankCapacity < tankCapacityCheck)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            this.FuelQuantity += liters * TANK_REFUEL;
        }
    }
}
