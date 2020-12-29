using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private Warrior attacker;
        [SetUp]
        public void Setup()
        {
            attacker = new Warrior(name:"James", damage:100, hp:100);
        }

        [Test]
        public void ConstructorShouldInitializeObjectSuccessfully()
        {
            Assert.AreEqual("James", attacker.Name);
            Assert.AreEqual(100, attacker.Damage);
            Assert.AreEqual(100, attacker.HP);
        }

        [Test]
        public void NameValidatorWithNullNameShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, 100, 100));
        }

        [Test]
        public void NameValidatorWithEmptyNameShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(string.Empty, 100, 100));

        }

        [Test]
        public void NameValidatorWithWhitespaceNameShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("     ", 100, 100));
        }

        [Test]
        public void DamageValidatorWithZeroDamageShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("James", 0, 100));
        }

        [Test]
        public void DamageValidatorWithNegativeDamageShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("James", -1, 100));
        }

        [Test]
        public void HPValidatorWithNegativeHpShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("James", 100, -1));
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void AttackerAttacksWithHPLowerThanOrEqual30ShouldThrowException(int attackerHP)
        {
            attacker = new Warrior(name:"James", damage:100, hp:attackerHP);
            Warrior defender = new Warrior(name:"Bran", damage:10, hp:50);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void DefenderDefendsWithHPLowerThanOrEqual30ShouldThrowException(int defenderHP)
        {
            Warrior defender = new Warrior(name:"Bran", damage:50, hp:defenderHP);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void AttackerAttacksStrongerDefenderShouldThrowException()
        {
            Warrior defender = new Warrior(name:"Bran", damage:120, hp:200);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        public void AttackShouldDecreaseBothWarriorsHp()
        {
            Warrior attacker = new Warrior(name:"James", damage:10, hp:100);
            Warrior defender = new Warrior(name:"Bran", damage:10, hp:100);

            int expectedAttackerHP = 90;
            int expectedDefenderHP = 90;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [Test]
        public void StrongerAttackerShouldKillDefender()
        {
            Warrior defender = new Warrior(name:"Bran", damage:50, hp:50);

            int expectedDefenderHP = 0;
            int expectedAttackerHP = attacker.HP - defender.Damage;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }
    }
}