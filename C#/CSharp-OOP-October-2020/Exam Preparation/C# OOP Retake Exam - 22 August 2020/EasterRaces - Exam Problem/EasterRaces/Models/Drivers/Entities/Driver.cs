using System;

using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Models.Drivers.Entities
{
    public class Driver : IDriver
    {
        private const int minModelNameLength = 5;
        private string name;

        public Driver(string name)
        {
            this.Name = name;   
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < minModelNameLength)
                {
                    string exMessage = string.Format(ExceptionMessages.InvalidName, value, minModelNameLength);
                    throw new ArgumentException(exMessage);
                }
                this.name = value;
            }
        }

        public ICar Car { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.CarInvalid);
            }

            this.Car = car;
            this.CanParticipate = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
