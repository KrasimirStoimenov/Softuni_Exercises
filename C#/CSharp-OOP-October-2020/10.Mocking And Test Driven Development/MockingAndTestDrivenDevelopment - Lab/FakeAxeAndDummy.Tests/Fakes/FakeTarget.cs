using FakeAxeAndDummy.Contracts;

namespace FakeAxeAndDummy.Tests.Fakes
{
    public class FakeTarget : ITarget
    {
        public int Health => 100;

        public int GiveExperience()
        {
            return 20;
        }

        public bool IsDead()
        {
            return true;
        }

        public void TakeAttack(int attackPoints)
        {
        }
    }
}
