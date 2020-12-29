using FakeAxeAndDummy.Contracts;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void KillingTargetShouldGiveExperience()
    {
        Mock<IWeapon> fakeWeapon = new Mock<IWeapon>();
        Mock<ITarget> fakeTarget = new Mock<ITarget>();
        fakeTarget.Setup(x => x.IsDead()).Returns(true);
        fakeTarget.Setup(t => t.GiveExperience()).Returns(20);
        Hero hero = new Hero("Bran", fakeWeapon.Object);

        hero.Attack(fakeTarget.Object);

        Assert.AreEqual(20, hero.Experience);
    }
}