using System;
using System.Collections.Generic;
using System.Text;

namespace _04._Raw_Data
{
    class Cargo
    {
        public int Weight { get; set; }

        public string Type { get; set; }

        public Cargo(int weight, string type)
        {
            this.Weight = weight;
            this.Type = type;
        }
    }
}
