using System;
using System.Collections.Generic;
using System.Text;

namespace _08._Vehicle_Catalogue
{
    class Truck
    {
        //Define a class Truck with the following properties: Brand, Model and Weight.
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }

        public Truck(string brand, string model, int weight)
        {
            this.Brand = brand;
            this.Model = model;
            this.Weight = weight;
        }
    }
}
