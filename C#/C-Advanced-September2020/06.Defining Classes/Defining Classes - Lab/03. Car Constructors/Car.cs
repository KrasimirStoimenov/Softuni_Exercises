using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }
        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public string Make
        {
            get => this.make;
            set => this.make = value;
        }
        public string Model
        {
            get => this.model;
            set => this.model = value;
        }

        public int Year
        {
            get => this.year;
            set => this.year = value;
        }
        public double FuelQuantity
        {
            get => this.fuelQuantity;
            set => this.fuelQuantity = value;
        }
        public double FuelConsumption
        {
            get => fuelConsumption;
            set => fuelConsumption = value;
        }

        public void Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption / 100;

            if (this.FuelQuantity >= fuelNeeded)
            {
                this.FuelQuantity -= fuelNeeded;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: { this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($"Fuel: {this.FuelQuantity:F2}L");

            return sb.ToString().TrimEnd();
        }
    }
}
