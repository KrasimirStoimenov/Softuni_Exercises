namespace _01.Vehicles.Models
{
    public class Car : Vehicle
    {
        private const double AIR_CONDITION_INCREASED_CONSUMPTION = 0.9;
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += AIR_CONDITION_INCREASED_CONSUMPTION;
        }
    }
}
