using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        dummy = new Dummy(10, 10);
    }
    [Test]
    public void DummyShouldLoseHealthWhenAttacked()
    {
        //act
        dummy.TakeAttack(10);
        int expectedResult = 0;
        int actualResult = dummy.Health;

        //assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    [TestCase(10)]
    [TestCase(11)]
    public void DeadDummyShouldThrowException(int attackTaken)
    {
        dummy.TakeAttack(attackTaken);
        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10));
    }

    [Test]
    public void DeadDummyShouldGiveXp()
    {
        dummy.TakeAttack(10);
        int expectedXp = 10;
        int actualXp = dummy.GiveExperience();

        //assert
        Assert.AreEqual(expectedXp, actualXp);
    }

    [Test]
    public void AliveDummyShouldNotGiveXP()
    {
        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }
}
