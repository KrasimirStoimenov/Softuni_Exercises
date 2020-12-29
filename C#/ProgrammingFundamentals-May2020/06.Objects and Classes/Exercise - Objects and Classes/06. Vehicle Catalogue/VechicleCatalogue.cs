using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Vehicle_Catalogue
{
    class VechicleCatalogue
    {
        public string Type { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public int HorsePower { get; set; }

        public VechicleCatalogue(string type, string model, string color, int horsepower)
        {
            this.Type = type;
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsepower;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type: {this.Type}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Color: {this.Color}");
            sb.AppendLine($"Horsepower: {this.HorsePower}");

            return sb.ToString().Trim() ;
        }
    }
}
