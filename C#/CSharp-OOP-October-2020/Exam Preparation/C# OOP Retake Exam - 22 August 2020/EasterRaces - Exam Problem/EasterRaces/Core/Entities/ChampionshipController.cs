using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using EasterRaces.Core.Contracts;
using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<ICar> carRepository;
        private IRepository<IDriver> driverRepository;
        private IRepository<IRace> raceRepository;
        public ChampionshipController()
        {
            this.carRepository = new CarRepository();
            this.driverRepository = new DriverRepository();
            this.raceRepository = new RaceRepository();

        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            if (this.driverRepository.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            if (this.carRepository.GetByName(carModel) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarNotFound, carModel));
            }

            var car = this.carRepository.GetByName(carModel);
            var driver = this.driverRepository.GetByName(driverName);

            driver.AddCar(car);

            return string.Format(OutputMessages.CarAdded, driver.Name, car.Model);
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            if (this.raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            if (this.driverRepository.GetByName(driverName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.DriverNotFound, driverName));
            }

            var race = this.raceRepository.GetByName(raceName);
            var driver = this.driverRepository.GetByName(driverName);

            race.AddDriver(driver);

            return string.Format(OutputMessages.DriverAdded, driverName, raceName);
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.carRepository.GetByName(model) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CarExists, model));
            }
            ICar car = null;
            if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }
            else if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }


            this.carRepository.Add(car);

            return string.Format(OutputMessages.CarCreated, car.GetType().Name, model);
        }

        public string CreateDriver(string driverName)
        {

            if (this.driverRepository.GetByName(driverName) != null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriversExists, driverName));
            }

            var driver = new Driver(driverName);
            this.driverRepository.Add(driver);

            return string.Format(OutputMessages.DriverCreated, driverName);

        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExists, name));
            }

            var race = new Race(name, laps);
            this.raceRepository.Add(race);

            return string.Format(OutputMessages.RaceCreated, name);
        }

        public string StartRace(string raceName)
        {
            if (this.raceRepository.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var race = this.raceRepository.GetByName(raceName);

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            List<IDriver> drivers = this.driverRepository
                    .GetAll()
                    .Where(x => x.CanParticipate == true)
                    .OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps))
                    .Take(3)
                    .ToList();


            this.raceRepository.Remove(race);

            var sb = new StringBuilder();

            sb.AppendLine($"Driver {drivers[0].Name} wins {raceName} race.");
            sb.AppendLine($"Driver {drivers[1].Name} is second in {raceName} race.");
            sb.AppendLine($"Driver {drivers[2].Name} is third in {raceName} race.");

            return sb.ToString().TrimEnd();

            ;
        }
    }
}
