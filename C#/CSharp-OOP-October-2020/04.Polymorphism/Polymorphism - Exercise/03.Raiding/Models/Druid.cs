namespace _03.Raiding.Models
{
    public class Druid : BaseHero
    {
        public Druid(string name)
            : base(name)
        {
        }

        public override int Power => 80;

        public override string CastAbility()
        {
            return $"Druid - {this.Name} healed for {this.Power}";
        }
    }
}
