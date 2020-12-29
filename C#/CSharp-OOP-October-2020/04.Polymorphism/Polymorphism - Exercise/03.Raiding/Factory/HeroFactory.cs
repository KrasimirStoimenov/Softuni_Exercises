using _03.Raiding.Models;
using _03.Raiding.Models.Contracts;

namespace _03.Raiding.Factory
{
    public class HeroFactory
    {
        public IHero CreateHero(string type, string name)
        {
            IHero hero = null;
            if (type == "Druid")
            {
                hero = new Druid(name);
            }
            else if (type == "Paladin")
            {
                hero = new Paladin(name);
            }
            else if (type == "Rogue")
            {
                hero = new Rogue(name);
            }
            else if (type == "Warrior")
            {
                hero = new Warrior(name);
            }
            return hero;
        }

    }
}
