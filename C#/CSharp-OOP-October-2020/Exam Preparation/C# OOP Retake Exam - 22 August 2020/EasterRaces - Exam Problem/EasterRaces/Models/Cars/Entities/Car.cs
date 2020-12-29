using System;

using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Cars.Contracts;

namespace EasterRaces.Models.Cars.Entities
{
    public abstract class Car : ICar
    {
        private const int minModelNameLength = 4;
        private int minHorsePower;
        private int maxHorsePower;
        private int horsePower;
        private string model;


        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.minHorsePower = minHorsePower;
            this.maxHorsePower = maxHorsePower;
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < minModelNameLength)
                {
                    string exMessage = string.Format(ExceptionMessages.InvalidModel, value, minModelNameLength);
                    throw new ArgumentException(exMessage);
                }
                this.model = value;
            }
        }

        public int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            private set
            {
                if (value < minHorsePower || value > maxHorsePower)
                {
                    string exMessage = string.Format(ExceptionMessages.InvalidHorsePower, value);
                    throw new ArgumentException(exMessage);
                }
                this.horsePower = value;
            }

        }
        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            return this.CubicCentimeters / this.HorsePower * laps;
        }



    }
}
