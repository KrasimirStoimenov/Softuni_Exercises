using NUnit.Framework;
using System;

namespace Computers.Tests
{
    public class Tests
    {
        private Computer computer;
        private ComputerManager computerManager;

        [SetUp]
        public void Setup()
        {
            this.computerManager = new ComputerManager();
            this.computer = new Computer("Test", "Test", 100);
            this.computerManager.AddComputer(computer);
        }

        [Test]
        [Category("Constructor")]
        public void ConstructorShouldWorkAsExpected()
        {
            this.computerManager = new ComputerManager();

            Assert.IsNotNull(computerManager);
            Assert.IsNotNull(this.computerManager.Computers);
        }

        [Test]
        [Category("CountProperty")]
        public void CountPropertyShouldWorkAsExpected()
        {
            Assert.AreEqual(1, this.computerManager.Count);

            this.computerManager.AddComputer(new Computer("Test2", "A", 15));

            Assert.AreEqual(2, this.computerManager.Count);
            Assert.AreEqual(2, this.computerManager.Computers.Count);
        }


        [Test]
        [Category("AddMethod")]
        public void AddMethodShouldWorkAsExpected()
        {
            this.computerManager.AddComputer(new Computer("Test2", "A", 15));

            Assert.AreEqual(2, this.computerManager.Count);
            Assert.AreEqual(2, this.computerManager.Computers.Count);
        }

        [Test]
        [Category("AddMethod")]
        public void AddingComputerWithExistingParametersShouldThrowArgumentException()
        {
            var computer = new Computer("Test", "Test", 10);
            Assert.Throws<ArgumentException>(() => this.computerManager.AddComputer(computer));
        }

        [Test]
        [Category("AddMethod")]
        public void AddingComputerWithNullComputerShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.AddComputer(null));
        }

        [Test]
        [Category("RemoveMethod")]
        public void RemoveComputerShouldWorkAsExpected()
        {
            var computer = this.computerManager.RemoveComputer("Test", "Test");
            Assert.AreEqual(this.computer, computer);
            Assert.AreEqual(0, this.computerManager.Computers.Count);
            Assert.AreEqual(0, this.computerManager.Count);
        }
        [Test]
        [Category("RemoveMethod")]
        public void RemoveMethodShouldThrowExceptionIfPassedNullManufacturer()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.RemoveComputer(null, "A"));

        }
        [Test]
        [Category("RemoveMethod")]
        public void RemoveMethodShouldThrowExceptionIfPassedNullModel()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.RemoveComputer("Test", null));

        }

        [Test]
        [Category("GetComputerMethod")]
        public void GetComputerMethodShouldWorkAsExpected()
        {
            var computer = this.computerManager.GetComputer("Test", "Test");
            Assert.AreSame(this.computer, computer);
        }

        [Test]
        [Category("GetComputerMethod")]
        public void ComputerWhichDoesntExistShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => this.computerManager.GetComputer("Invalid", "Invalid"));
        }

        [Test]
        [Category("GetComputerMethod")]
        public void PassingNullManufacturerToGetComputerMethodShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputer(null, "A"));
        }

        [Test]
        [Category("GetComputerMethod")]
        public void PassingNullModelToGetComputerMethodShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputer("Test", null));
        }

        [Test]
        [Category("GetComputerByManufacturer")]
        public void GetComputerByManufacturerMethodShouldWorkAsExpected()
        {
            var computer1 = new Computer("Test", "A", 10);
            var computer2 = new Computer("ASD", "A", 10);
            this.computerManager.AddComputer(computer1);
            this.computerManager.AddComputer(computer2);
            var computersByManufacturer = this.computerManager.GetComputersByManufacturer("Test");
            CollectionAssert.Contains(computersByManufacturer, this.computer);
            CollectionAssert.Contains(computersByManufacturer, computer1);
            CollectionAssert.DoesNotContain(computersByManufacturer, computer2);
        }

        [Test]
        [Category("GetComputerByManufacturer")]
        public void PassingNullManufacturerShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputersByManufacturer(null));
        }


    }
}