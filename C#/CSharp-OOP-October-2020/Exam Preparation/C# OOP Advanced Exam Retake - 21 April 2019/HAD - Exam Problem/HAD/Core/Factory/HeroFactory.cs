using System;
using System.Linq;
using System.Reflection;
using HAD.Contracts;
using HAD.Core.Factory.Contracts;
using HAD.Entities.Heroes;

namespace HAD.Core.Factory
{
    public class HeroFactory : IHeroFactory
    {
        public IHero CreateHero(string heroType, string name)
        {
            //IHero hero = null;
            var type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name == heroType);
            var ctorParameters = new object[] { name };
            IHero hero = Activator.CreateInstance(type, ctorParameters) as IHero;
            //switch (heroType)
            //{
            //    case "Assassin":
            //        hero = new Assassin(name);
            //        break;
            //    case "Barbarian":
            //        hero = new Barbarian(name);
            //        break;
            //    case "Wizard":
            //        hero = new Wizard(name);
            //        break;
            //}

            return hero;
        }
    }
}
