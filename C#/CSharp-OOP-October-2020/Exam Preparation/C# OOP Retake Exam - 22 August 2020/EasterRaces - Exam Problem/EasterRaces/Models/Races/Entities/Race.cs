using System;
using System.Linq;
using System.Collections.Generic;

using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private const int minModelNameLength = 5;
        private string name;
        private int laps;
        private ICollection<IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.drivers = new List<IDriver>();
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
        public int Laps
        {
            get
            {
                return this.laps;
            }
            private set
            {
                if (value < 1)
                {
                    string exMessage = string.Format(ExceptionMessages.InvalidNumberOfLaps, value, minModelNameLength);
                    throw new ArgumentException(exMessage);
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers.ToList().AsReadOnly();

        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(ExceptionMessages.DriverInvalid);
            }

            if (driver.Car == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate, driver.Name));
            }

            if (this.drivers.Contains(driver))
            {
                throw new ArgumentNullException(string.Format(ExceptionMessages.DriverAlreadyAdded, driver.Name, this.Name));
            }

            this.drivers.Add(driver);
        }
    }
}
