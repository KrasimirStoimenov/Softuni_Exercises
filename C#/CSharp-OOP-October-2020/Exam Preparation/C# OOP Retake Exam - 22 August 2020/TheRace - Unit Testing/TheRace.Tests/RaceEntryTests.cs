using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        private UnitCar car;
        private UnitDriver driver;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
            this.car = new UnitCar("Test", 100, 10);
            this.driver = new UnitDriver("Test", this.car);
        }

        [Test]
        public void ConstructorShouldInitializeDataCorrectly()
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.IsNotNull(raceEntry);
        }

        [Test]
        public void AddDriverShouldWorkCorrectly()
        {
            var stringResult = this.raceEntry.AddDriver(this.driver);

            Assert.AreEqual(1, this.raceEntry.Counter);
            Assert.AreEqual("Driver Test added in race.", stringResult);
        }

        [Test]
        public void PassingNullAsDriverShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(null));
        }

        [Test]
        public void TryingToAddExistingDriverShouldThrowException()
        {
            this.raceEntry.AddDriver(this.driver);
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(this.driver));
        }

        [Test]
        public void LessDriversThanMinimalParticipantsShouldThrowException()
        {
            this.raceEntry.AddDriver(this.driver);
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHPShouldWorkAsExpected()
        {
            var secondDriver = new UnitDriver("Second", new UnitCar("Tesla", 100, 1500));
            var thirdDriver = new UnitDriver("Third", new UnitCar("BMW", 100, 4000));

            this.raceEntry.AddDriver(driver);
            this.raceEntry.AddDriver(secondDriver);
            this.raceEntry.AddDriver(thirdDriver);

            var result = this.raceEntry.CalculateAverageHorsePower();
            Assert.AreEqual(100, result);
        }
    }
}