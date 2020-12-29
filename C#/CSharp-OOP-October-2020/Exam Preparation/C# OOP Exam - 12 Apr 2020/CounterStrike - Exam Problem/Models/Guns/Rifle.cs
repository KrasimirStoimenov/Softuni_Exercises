namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int bulletsFired = 10;
        private int bulletsCount;

        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
            this.bulletsCount = bulletsCount;
        }

        public override int Fire()
        {
            if (this.BulletsCount < bulletsFired)
            {
                return 0;
            }
            this.BulletsCount -= bulletsFired;
            return bulletsFired;
        }
    }
}
