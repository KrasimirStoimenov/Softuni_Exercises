namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;
        [SetUp]
        public void SetUp()
        {
            this.robot = new Robot("Test", 100);
            this.robotManager = new RobotManager(2);

        }
        [Test]
        [Category("Constructor")]
        public void InitializeManagerShouldWorkAsExpected()
        {
            this.robotManager = new RobotManager(5);
            Assert.IsNotNull(this.robotManager);
        }
        [Test]
        [Category("Capacity")]
        public void InitializeRobotManagerWithCapacityOf2ShouldWorkAsExpected()
        {
            Assert.AreEqual(2, this.robotManager.Capacity);
        }

        [Test]
        [Category("Capacity")]
        public void PassingNegativeDataForCapacityShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-1));
        }

        [Test]
        [Category("Count")]
        public void CountGetterShouldWorkAsExpected()
        {
            this.robotManager.Add(robot);
            Assert.AreEqual(1, this.robotManager.Count);
        }

        [Test]
        [Category("Add")]
        public void AddMethodShouldWorkAsExpected()
        {
            this.robotManager.Add(this.robot);
            Assert.AreEqual(1, this.robotManager.Count);
        }

        [Test]
        [Category("Add")]
        public void AddingRobotWhichIsAlreadyBeenAddedShouldThrowInvalidOperationException()
        {
            this.robotManager.Add(this.robot);
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Add(this.robot));
        }

        [Test]
        [Category("Add")]
        public void TryToAddMoreRobotsThanManagerCapacityShouldThrowInvalidOperationException()
        {
            this.robotManager.Add(this.robot);
            this.robotManager.Add(new Robot("Test2", 50));
            Assert.Throws<InvalidOperationException>(() => this.robotManager.Add(new Robot("Test3", 10)));
            Assert.AreEqual(2, this.robotManager.Count);
        }

        [Test]
        [Category("Remove")]
        public void RemoveMethodShouldWorkAsExpected()
        {
            this.robotManager.Add(this.robot);
            this.robotManager.Remove("Test");

            Assert.AreEqual(0, this.robotManager.Count);
        }
        [Test]
        [Category("Remove")]
        public void PassingNullAsNameShouldThrowInvalidOperationException()
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() => this.robotManager.Remove(null));
        }

        [Test]
        [Category("Work")]
        public void WorkMethodShouldWorkAsExpected()
        {
            this.robotManager.Add(this.robot);
            this.robotManager.Work("Test", "A", 60);

            Assert.AreEqual(40, this.robot.Battery);
        }

        [Test]
        [Category("Work")]
        public void PassNullRobotNameShouldThrowInvalidOperationException()
        {
            this.robotManager.Add(this.robot);
            this.robotManager.Work("Test", "A", 60);

            Assert.Throws<InvalidOperationException>(() => this.robotManager.Work(null, "A", 60));
        }

        [Test]
        [Category("Work")]
        public void PassBatteryUsageMoreThanRobotsBatteryShouldThrowInvalidOperationException()
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() => this.robotManager.Work("Test", "A", 120));
        }

        [Test]
        [Category("Charge")]
        public void ChargeMethodShouldWorkAsExpected()
        {
            this.robotManager.Add(this.robot);
            this.robotManager.Work("Test", "A", 60);

            Assert.AreEqual(40, this.robot.Battery);

            this.robotManager.Charge("Test");

            Assert.AreEqual(100, this.robot.Battery);
        }

        [Test]
        [Category("Charge")]
        public void TryToChargeRobotWithNullNameShouldThrowInvalidOperationException()
        {
            this.robotManager.Add(this.robot);

            Assert.Throws<InvalidOperationException>(() => this.robotManager.Charge(null));
        }
    }
}
