using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<VechicleCatalogue> vechicleList = new List<VechicleCatalogue>();

            FillVechicleCatalogueList(vechicleList);
            PrintVechicles(vechicleList);
            PrintAverageHorsepower(vechicleList);
        }

        static void PrintAverageHorsepower(List<VechicleCatalogue> vechicleList)
        {
            List<VechicleCatalogue> cars = vechicleList.Where(x => x.Type == "Car").ToList();
            List<VechicleCatalogue> trucks = vechicleList.Where(x => x.Type == "Truck").ToList();
            decimal carsAverageHp = 0;
            decimal trucksAverageHp = 0;
            if (cars.Any())
            {
                carsAverageHp = GetAverageHp(cars);

            }
            if (trucks.Any())
            {
                trucksAverageHp = GetAverageHp(trucks);

            }
            Console.WriteLine($"Cars have average horsepower of: {carsAverageHp:F2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAverageHp:F2}.");

        }

        static decimal GetAverageHp(List<VechicleCatalogue> catalogue)
        {
            decimal sum = 0;
            for (int i = 0; i < catalogue.Count; i++)
            {
                sum += catalogue[i].HorsePower;
            }

            return sum / catalogue.Count;
        }

        static void PrintVechicles(List<VechicleCatalogue> vechicleList)
        {
            string command;
            while ((command = Console.ReadLine()) != "Close the Catalogue")
            {
                VechicleCatalogue currentVechicle = vechicleList.Find(m => m.Model == command);
                if (currentVechicle != null)
                {
                    Console.WriteLine(currentVechicle.ToString());
                }
            }
        }

        static void FillVechicleCatalogueList(List<VechicleCatalogue> vechicleList)
        {
            string vechicle;
            while ((vechicle = Console.ReadLine()) != "End")
            {
                string[] vechicleArgs = vechicle.Split();
                string type = vechicleArgs[0];
                string model = vechicleArgs[1];
                string color = vechicleArgs[2];
                int hp = int.Parse(vechicleArgs[3]);

                string typeFormated = GetTypeFormated(type);

                VechicleCatalogue catalogue = new VechicleCatalogue(typeFormated, model, color, hp);
                vechicleList.Add(catalogue);
            }
        }

        static string GetTypeFormated(string type)
        {
            string output = string.Empty;
            output += char.ToUpper(type[0]);
            for (int i = 1; i < type.Length; i++)
            {
                output += type[i];
            }

            return output;
        }
    }
    //class VechicleCatalogue
    //{
    //    public string Type { get; set; }

    //    public string Model { get; set; }

    //    public string Color { get; set; }

    //    public int HorsePower { get; set; }

    //    public VechicleCatalogue(string type, string model, string color, int horsepower)
    //    {
    //        this.Type = type;
    //        this.Model = model;
    //        this.Color = color;
    //        this.HorsePower = horsepower;
    //    }

    //    public override string ToString()
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        sb.AppendLine($"Type: {this.Type}");
    //        sb.AppendLine($"Model: {this.Model}");
    //        sb.AppendLine($"Color: {this.Color}");
    //        sb.AppendLine($"Horsepower: {this.HorsePower}");

    //        return sb.ToString().Trim();
    //    }
    //}


}
