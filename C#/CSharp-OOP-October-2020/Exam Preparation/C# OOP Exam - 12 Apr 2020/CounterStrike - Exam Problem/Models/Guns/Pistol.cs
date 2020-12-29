namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int bulletsFired = 1;

        public Pistol(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
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
