namespace NeedForSpeed.Vehicle
{
    public class Vehicle
    {
        private const double DefaultFuelConsumption = 1.25;

        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public int HorsePower { get; }

        public double Fuel { get; set; }

        public virtual double FuelConsumption { get => DefaultFuelConsumption; }

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * FuelConsumption;
        }
    }
}
