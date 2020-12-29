using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._Plant_Discovery
{
    class Plant
    {
        public string Name { get; set; }

        public int Rarity { get; set; }

        public List<double> Rating { get; set; }

        public Plant(string name, int rarity)
        {
            this.Name = name;
            this.Rarity = rarity;
            this.Rating = new List<double>();
        }

        public double Average()
        {
            double average = 0;
            if (Rating.Count != 0)
            {
                average = Rating.Average();
            }

            return average;

        }

        public override string ToString()
        {

                return $"- {Name}; Rarity: {Rarity}; Rating: {Average():F2}";
        }

    }
}
