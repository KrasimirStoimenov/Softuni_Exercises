using System;
using System.Collections.Generic;
using System.Text;

namespace _03._P_rates
{
    class City
    {
        public string CityName { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }

        public City(string name, int population, int gold)
        {
            this.CityName = name;
            this.Population = population;
            this.Gold = gold;
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"{CityName} -> Population: {Population} citizens, Gold: {Gold} kg");
            return output.ToString();
        }
    }
}
