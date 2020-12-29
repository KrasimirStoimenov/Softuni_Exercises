using System;
using System.Collections.Generic;

using _06.FoodShortage.Models;
using _06.FoodShortage.Interfaces;
using System.Linq;

namespace _05.BirthdayCelebrations.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<IBuyer> buyers;
        public Engine()
        {
            this.buyers = new List<IBuyer>();
        }
        public void Run()
        {
            FillBuyersList();
            BuyersWhoBoughtFood(buyers);
            PrintTotalFoodBought(buyers);

        }

        private void PrintTotalFoodBought(ICollection<IBuyer> buyers)
        {
            int foodBought = 0;
            foreach (var buyer in buyers)
            {
                foodBought += buyer.Food;
            }
            Console.WriteLine(foodBought);
        }

        private void BuyersWhoBoughtFood(ICollection<IBuyer> buyers)
        {
            string buyer;
            while ((buyer = Console.ReadLine()) != "End")
            {
                IBuyer currentBuyer = buyers.FirstOrDefault(x => x.Name == buyer);
                if (currentBuyer != null)
                {
                    currentBuyer.BuyFood();
                }
            }
        }

        private void FillBuyersList()
        {
            int peopleCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < peopleCount; i++)
            {
                string[] peopleArgs = Console.ReadLine().Split(" ");

                if (peopleArgs.Length > 3)
                {
                    AddCitizenBuyer(peopleArgs);
                }
                else
                {
                    AddRebelBuyer(peopleArgs);
                }
            }
        }

        private void AddRebelBuyer(string[] peopleArgs)
        {
            string name = peopleArgs[0];
            int age = int.Parse(peopleArgs[1]);
            string group = peopleArgs[2];

            IBuyer rebelBuyer = new Rebel(name, age, group);
            buyers.Add(rebelBuyer);
        }

        private void AddCitizenBuyer(string[] peopleArgs)
        {
            //citizen
            string name = peopleArgs[0];
            int age = int.Parse(peopleArgs[1]);
            string id = peopleArgs[2];
            string birthday = peopleArgs[3];

            IBuyer citizenBuyer = new Citizen(name, age, id, birthday);
            buyers.Add(citizenBuyer);
        }
    }
}
