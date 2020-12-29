namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    public class ComputerTests
    {
        private Part part;
        private Computer computer;
        [SetUp]
        public void Setup()
        {
            this.part = new Part("Test", 10);
            this.computer = new Computer("TestComputer");
        }

        [Test]
        [Category("Constructor")]
        public void CtorShouldInitializeDataCorrectly()
        {
            this.computer = new Computer("Test");

            Assert.IsNotNull(computer);
            Assert.IsNotNull(computer.Parts);
            Assert.AreEqual(0, computer.Parts.Count);
            Assert.AreEqual("Test", this.computer.Name);
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        [Category("NameProperty")]
        public void TryInitializeDataWithInvalidNameShouldThrowException(string name)
        {
            Assert.Throws<ArgumentNullException>(() => this.computer = new Computer(name));
        }

        [Test]
        [Category("AddPartMethod")]
        public void AddPartMethodShouldWorkAsExpected()
        {
            this.computer.AddPart(this.part);

            Assert.AreEqual(1, this.computer.Parts.Count);

            this.computer.AddPart(new Part("A", 15));

            Assert.AreEqual(2, this.computer.Parts.Count);
        }

        [Test]
        [Category("AddPartMethod")]
        public void PassingNullPartToAddMethodShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => this.computer.AddPart(null));
        }


        [Test]
        [Category("RemovePartMethod")]
        public void RemovePartMethodShouldWorkAsExpected()
        {
            this.computer.AddPart(this.part);
            this.computer.AddPart(new Part("A", 15));
            this.computer.AddPart(new Part("B", 10));

            Assert.AreEqual(3, this.computer.Parts.Count);

            Assert.IsTrue(this.computer.RemovePart(this.part));
            Assert.AreEqual(2, this.computer.Parts.Count);
        }

        [Test]
        [Category("RemovePartMethod")]
        public void RemovePartThatDoesNotExistShouldReturnFalse()
        {
            Assert.IsFalse(this.computer.RemovePart(new Part("A", 5)));
        }

        [Test]
        [Category("GetPartMethod")]
        public void GetPartMethodShouldWorkAsExpected()
        {
            this.computer.AddPart(this.part);
            var currentPart = this.computer.GetPart("Test");
            Assert.AreSame(currentPart, this.part);
        }

        [Test]
        [Category("GetPartMethod")]
        public void GetPartThatDoesNotExistShouldReturnNull()
        {
            var part = this.computer.GetPart("ABC");
            Assert.AreSame(null, part);
        }

        [Test]
        [Category("TotalPrice")]
        public void TotalPriceMethodShouldWorkAsExpected()
        {
            var firstPart = new Part("First", 10);
            var secondPart = new Part("Second", 15);
            var thridPart = new Part("Third", 20);
            this.computer.AddPart(firstPart);
            this.computer.AddPart(secondPart);
            this.computer.AddPart(thridPart);
            var result = this.computer.TotalPrice;
            Assert.AreEqual(45, result);
        }

    }

}