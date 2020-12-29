using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tire
    {
        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
        public int Year { get; private set; }

        public double Pressure { get; private set; }

    }
}
