using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            this.car = new Car("BMW", "E90", 6, 60);
        }

        [Test]
        [TestCase("BMW", "E90", 6, 60)]
        [TestCase("BMW", "F10", 10, 70)]
        [TestCase("   ", "  ", 10, 70)]
        public void ConstructorShouldInitializeCarCorrectly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void InitializeCarWithWrongStringArgumentsShouldThrowException(string arguments)
        {
            Assert.Throws<ArgumentException>(() => car = new Car(arguments, "E90", 6, 60));
            Assert.Throws<ArgumentException>(() => car = new Car("BMW", arguments, 6, 60));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void InitializeCarWithWrongIntArgumentsShouldThrowException(int arguments)
        {
            Assert.Throws<ArgumentException>(() => car = new Car("BMW", "E90", arguments, 60));
            Assert.Throws<ArgumentException>(() => car = new Car("BMW", "E90", 6, arguments));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelingWtihFuelBelowOrEqualToZeroShouldThrowException(double fuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        public void RefuelMethodShouldWorkCorrectly()
        {
            car.Refuel(50);
            Assert.AreEqual(50, car.FuelAmount);
        }

        [Test]
        public void RefuelingWithMoreFuelThanCappacity()
        {
            car.Refuel(100);
            Assert.AreEqual(car.FuelCapacity, car.FuelAmount);
        }

        [Test]
        public void DriveCarShouldWorkCorrectly()
        {
            car.Refuel(60);
            car.Drive(100);

            Assert.AreEqual(54, car.FuelAmount);
        }

        [Test]
        public void DriveCarWithoutEnoughFuelShouldThrowException()
        {
            car.Refuel(5);
            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        }

    }
}