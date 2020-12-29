using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Need_for_Speed_III
{
    class Car
    {
        //{car}|{mileage}|{fuel}

        public string CarName { get; set; }
        public int Mileage { get; set; }

        public int Fuel { get; set; }

        public Car(string carName, int mileage, int fuel)
        {
            this.CarName = carName;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }
    }
}
