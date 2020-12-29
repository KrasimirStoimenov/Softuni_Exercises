using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Plant_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Plant> plants = new List<Plant>();

            FillingPlantsList(plants);
            ProccessingPlantCommands(plants);
            PrintOutput(plants);

        }

        static void PrintOutput(List<Plant> plants)
        {
            Console.WriteLine("Plants for the exhibition:");
            var orderedPlants = plants.OrderByDescending(r => r.Rarity).ThenByDescending(x => x.Average());

            Console.WriteLine(string.Join(Environment.NewLine, orderedPlants));
        }

        static void ProccessingPlantCommands(List<Plant> plants)
        {
            string command;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] cmdArgs = command.Split(new char[] { ':', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = cmdArgs[0];
                if (action != "Rate" && action != "Update" && action != "Reset")
                {
                    Console.WriteLine("error");
                    continue;
                }

                string plantName = cmdArgs[1];
                Plant current = plants.Find(x => x.Name == plantName);
                if (current == null)
                {
                    Console.WriteLine("error");
                    continue;
                }

                switch (action)
                {
                    case "Rate":
                        double rating = double.Parse(cmdArgs[2]);
                        current.Rating.Add(rating);
                        break;
                    case "Update":
                        int rarity = int.Parse(cmdArgs[2]);
                        current.Rarity = rarity;
                        break;
                    case "Reset":
                        current.Rating.Clear();
                        break;
                }
            }
        }

        static void FillingPlantsList(List<Plant> plants)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split("<->");
                string plantName = input[0];
                int rarity = int.Parse(input[1]);

                Plant current = plants.Find(x => x.Name == plantName);
                if (current == null)
                {
                    Plant plant = new Plant(plantName, rarity);
                    plants.Add(plant);
                }
                else
                {
                    current.Rarity = rarity;
                }

            }
        }
    }
    //class Plant
    //{
    //    public string Name { get; set; }

    //    public int Rarity { get; set; }

    //    public List<double> Rating { get; set; }

    //    public Plant(string name, int rarity)
    //    {
    //        this.Name = name;
    //        this.Rarity = rarity;
    //        this.Rating = new List<double>();
    //    }

    //    public double Average()
    //    {
    //        double average = 0;
    //        if (Rating.Count != 0)
    //        {
    //            average = Rating.Average();
    //        }

    //        return average;

    //    }

    //    public override string ToString()
    //    {

    //        return $"- {Name}; Rarity: {Rarity}; Rating: {Average():F2}";
    //    }

    //}


}
