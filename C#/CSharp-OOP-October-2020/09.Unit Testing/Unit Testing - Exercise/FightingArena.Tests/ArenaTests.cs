using FightingArena;
using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void ConstructorShouldInitializeEmptyListOfWarriors()
        {
            Assert.IsNotNull(arena);
        }

        [Test]
        public void SucsessfullyEnrollWarrior()
        {
            Warrior warrior = new Warrior("John", 100, 100);
            arena.Enroll(warrior);
            Assert.That(arena.Warriors.Contains(warrior));
            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void EnrollWarriorWithSameNameShouldThrowException()
        {
            Warrior warrior = new Warrior("John", 100, 100);
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
            Assert.AreEqual(1, arena.Count);

        }

        [Test]
        [TestCase("John", null)]
        [TestCase(null, "John")]
        [TestCase(null, null)]
        [TestCase("Pesho", "Gosho")]
        public void OneOfWarriorsAreMissingInTheListShouldThrowException(string firstFighter, string secondFighter)
        {
            arena.Enroll(new Warrior("Pesho", 100, 100));

            Assert.Throws<InvalidOperationException>(() => arena.Fight(firstFighter, secondFighter));
        }

        [Test]
        public void TestFightMethodWithAttackerAndDefender()

        {
            Warrior firstWarr = new Warrior("First", 10, 100);
            Warrior secondWarr = new Warrior("Second", 10, 100);
            this.arena.Enroll(firstWarr);
            this.arena.Enroll(secondWarr);

            int expectedAttackerHP = firstWarr.HP - secondWarr.Damage;
            int expectedDefenderHP = secondWarr.HP - firstWarr.Damage;

            this.arena.Fight(firstWarr.Name, secondWarr.Name);

            Assert.AreEqual(expectedAttackerHP, firstWarr.HP);
            Assert.AreEqual(expectedDefenderHP, secondWarr.HP);
        }

    }
}
