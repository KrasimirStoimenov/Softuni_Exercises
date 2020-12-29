using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Heroes_of_Code_and_Logic_VII
{
    class Hero
    {
        public string HeroName { get; set; }
        public int HitPoints { get; set; }
        public int ManaPoints { get; set; }

        public Hero(string name, int hp, int mp)
        {
            this.HeroName = name;
            this.HitPoints = hp;
            this.ManaPoints = mp;
        }

        public override string ToString()
        {
            StringBuilder overrided = new StringBuilder();
            overrided.AppendLine(HeroName);
            overrided.AppendLine($"  HP: {HitPoints}");
            overrided.AppendLine($"  MP: {ManaPoints}");
            return overrided.ToString();
        }
    }
}
