using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private ICollection<IBakedFood> foods;
        private ICollection<IDrink> drinks;
        private ICollection<ITable> tables;
        private decimal income;
        public Controller()
        {
            this.foods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink currentDrink = null;
            if (type == "Tea")
            {
                currentDrink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                currentDrink = new Water(name, portion, brand);
            }

            this.drinks.Add(currentDrink);

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood currentFood = null;
            if (type == "Bread")
            {
                currentFood = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                currentFood = new Cake(name, price);
            }

            this.foods.Add(currentFood);

            return string.Format(OutputMessages.FoodAdded, name, currentFood.GetType().Name);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable currentTable = null;
            if (type == "InsideTable")
            {
                currentTable = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                currentTable = new OutsideTable(tableNumber, capacity);
            }

            this.tables.Add(currentTable);

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            var sb = new StringBuilder();
            foreach (var table in this.tables.Where(x => x.IsReserved == false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {this.income:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var tableBill = table.Price;
            this.income += tableBill;
            table.Clear();

            var sb = new StringBuilder();

            sb
                .AppendLine($"Table: {tableNumber}")
                .AppendLine($"Bill: {tableBill:f2}");

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            var drink = this.drinks.FirstOrDefault(x => (x.Name == drinkName) && (x.Brand == drinkBrand));
            if (drink == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            table.OrderDrink(drink);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return $"Could not find table {tableNumber}";
            }

            var food = this.foods.FirstOrDefault(x => x.Name == foodName);
            if (food == null)
            {
                return $"No {foodName} in the menu";
            }

            table.OrderFood(food);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var tableForReservation = this.tables.FirstOrDefault(x => (x.Capacity > numberOfPeople) && (x.IsReserved == false));

            if (tableForReservation == null)
            {
                return $"No available table for {numberOfPeople} people";
            }

            tableForReservation.Reserve(numberOfPeople);

            return $"Table {tableForReservation.TableNumber} has been reserved for {numberOfPeople} people";
        }
    }
}
