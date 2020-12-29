using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        axe = new Axe(2, 2);
        dummy = new Dummy(10, 10);
    }
    [Test]
    public void WeaponLosesDurabilityAfterAttack()
    {
        //act
        axe.Attack(dummy);
        int expectedResult = 1;
        int actualResult = axe.DurabilityPoints;

        //assert
        //Assert.AreEqual(expectedResult, actualResult);
        Assert.That(expectedResult.Equals(actualResult));
    }

    [Test]
    public void AttackWithBrokenWeaponShouldThrowException()
    {
        axe.Attack(dummy);
        axe.Attack(dummy);
        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }
}