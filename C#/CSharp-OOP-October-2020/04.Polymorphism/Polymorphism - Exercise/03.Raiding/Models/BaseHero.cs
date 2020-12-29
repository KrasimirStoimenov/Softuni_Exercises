using _03.Raiding.Models.Contracts;

namespace _03.Raiding.Models
{
    public abstract class BaseHero : IHero
    {
        public BaseHero(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }
        public abstract int Power { get; }
        public abstract string CastAbility();
    }
}
