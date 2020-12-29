using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKm;
        private double travelledDistance;

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKm = fuelConsumption;
            this.TravelledDistance = 0;
        }

        public string Model { get => model; set => model = value; }
        public double FuelAmount { get => fuelAmount; set => fuelAmount = value; }
        public double FuelConsumptionPerKm { get => fuelConsumptionPerKm; set => fuelConsumptionPerKm = value; }
        public double TravelledDistance { get => travelledDistance; set => travelledDistance = value; }

        public void Drive(double distance)
        {
            double fuelNeedForDrive = distance * FuelConsumptionPerKm;
            if (this.FuelAmount >= fuelNeedForDrive)
            {
                this.TravelledDistance += distance;
                this.FuelAmount -= fuelNeedForDrive;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
