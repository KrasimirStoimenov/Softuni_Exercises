using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Cargo
    {
        public Cargo(string cargoType, int cargoWeight)
        {
            this.CargoType = cargoType;
            this.CargoWeight = cargoWeight;
        }
        public string CargoType { get; private set; }

        public int CargoWeight { get; private set; }
    }
}
