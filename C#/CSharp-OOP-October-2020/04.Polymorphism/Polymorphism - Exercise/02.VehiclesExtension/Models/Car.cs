namespace _02.VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double AIR_CONDITION_INCREASED_CONSUMPTION = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption += AIR_CONDITION_INCREASED_CONSUMPTION;
        }
    }
}
