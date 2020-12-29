using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03._P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<City> citiesGoods = new List<City>();
            TargetingCities(citiesGoods);
            PlunderCities(citiesGoods);
            PrintOutput(citiesGoods);
        }

        static void PrintOutput(List<City> citiesGoods)
        {
            if (citiesGoods.Any())
            {
                Console.WriteLine($"Ahoy, Captain! There are {citiesGoods.Count} wealthy settlements to go to:");
                Console.WriteLine(string.Join("", citiesGoods.OrderByDescending(x => x.Gold).ThenBy(x => x.CityName)));
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }

        static void PlunderCities(List<City> citiesGoods)
        {
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split("=>");
                string action = cmdArgs[0];
                string town = cmdArgs[1];
                City currentCity = citiesGoods.Find(x => x.CityName == town);
                switch (action)
                {
                    case "Plunder":
                        PlunderTown(currentCity, cmdArgs);
                        ValidateIfStillExistTheCityAfterPlunder(currentCity, citiesGoods);
                        break;
                    case "Prosper":
                        int gold = int.Parse(cmdArgs[2]);
                        if (gold < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            continue;
                        }
                        ProsperTown(currentCity, gold);
                        break;

                }
            }
        }

        static void ProsperTown(City currentCity, int gold)
        {
            currentCity.Gold += gold;
            Console.WriteLine($"{gold} gold added to the city treasury. {currentCity.CityName} now has {currentCity.Gold} gold.");
        }

        static void ValidateIfStillExistTheCityAfterPlunder(City currentCity, List<City> citiesGoods)
        {
            if (currentCity.Gold == 0 || currentCity.Population == 0)
            {
                citiesGoods.Remove(currentCity);
                Console.WriteLine($"{currentCity.CityName} has been wiped off the map!");
            }
        }

        static void PlunderTown(City currentCity, string[] cmdArgs)
        {
            int population = int.Parse(cmdArgs[2]);
            int gold = int.Parse(cmdArgs[3]);

            Console.WriteLine($"{currentCity.CityName} plundered! {gold} gold stolen, {population} citizens killed.");
            currentCity.Gold -= gold;
            currentCity.Population -= population;
        }

        static void TargetingCities(List<City> citiesGoods)
        {
            string cities;
            while ((cities = Console.ReadLine()) != "Sail")
            {
                string[] citiesArgs = cities.Split("||");
                string cityName = citiesArgs[0];
                int population = int.Parse(citiesArgs[1]);
                int gold = int.Parse(citiesArgs[2]);
                if (citiesGoods.Exists(x => x.CityName == cityName))
                {
                    City currentCity = citiesGoods.Find(x => x.CityName == cityName);
                    currentCity.Population += population;
                    currentCity.Gold += gold;
                }
                else
                {
                    City city = new City(cityName, population, gold);
                    citiesGoods.Add(city);
                }
            }
        }
    }
    //class City
    //{
    //    public string CityName { get; set; }
    //    public int Population { get; set; }
    //    public int Gold { get; set; }

    //    public City(string name, int population, int gold)
    //    {
    //        this.CityName = name;
    //        this.Population = population;
    //        this.Gold = gold;
    //    }
    //    public override string ToString()
    //    {
    //        StringBuilder output = new StringBuilder();
    //        output.AppendLine($"{CityName} -> Population: {Population} citizens, Gold: {Gold} kg");
    //        return output.ToString();
    //    }
    //}

}
