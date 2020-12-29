namespace _01.Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double AIR_CONDITION_INCREASED_CONSUMPTION = 1.6;
        private const double TANK_REFUEL = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += AIR_CONDITION_INCREASED_CONSUMPTION;
        }

        public override void Refuel(double liters)
        {
            this.FuelQuantity += liters * TANK_REFUEL;
        }
    }
}
