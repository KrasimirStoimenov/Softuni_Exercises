namespace _03.Raiding.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name)
            : base(name)
        {
        }

        public override int Power => 80;

        public override string CastAbility()
        {
            return $"Rogue - {this.Name} hit for {this.Power} damage";
        }
    }
}
