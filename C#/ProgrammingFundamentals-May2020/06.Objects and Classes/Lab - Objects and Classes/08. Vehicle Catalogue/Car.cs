using System;
using System.Collections.Generic;
using System.Text;

namespace _08._Vehicle_Catalogue
{
    class Car
    {
        //Define a class Car with the following properties: Brand, Model and Horse Power.

        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

        public Car(string brand, string model, int hp)
        {
            this.Brand = brand;
            this.Model = model;
            this.HorsePower = hp;
        }
    }
}
