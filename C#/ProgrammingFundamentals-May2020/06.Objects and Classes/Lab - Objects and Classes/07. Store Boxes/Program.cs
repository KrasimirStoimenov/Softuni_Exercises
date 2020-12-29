using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._Store_Boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            ReadItems(boxes);
            PrintOutput(boxes);
        }

        static void PrintOutput(List<Box> boxes)
        {
            Console.WriteLine(string.Join("", boxes.OrderByDescending(x => x.PriceForBox)));
        }

        static void ReadItems(List<Box> boxes)
        {
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] cmdArgs = command.Split();
                string serialNumber = cmdArgs[0];
                string itemName = cmdArgs[1];
                int quantity = int.Parse(cmdArgs[2]);
                decimal price = decimal.Parse(cmdArgs[3]);

                Item item = new Item(itemName, price);
                Box box = new Box(serialNumber, item, quantity);
                boxes.Add(box);
            }
        }
    }
    //class Item
    //{
    //    public Item(string name, decimal price)
    //    {
    //        Name = name;
    //        Price = price;
    //    }
    //    public string Name { get; set; }
    //    public decimal Price { get; set; }
    //}
    //class Box
    //{
    //    public Box(string serial, Item item, int quantity)
    //    {
    //        SerialNumber = serial;
    //        ItemQuantity = quantity;
    //        Item = item;
    //    }
    //    public Item Item { get; set; }
    //    public string SerialNumber { get; set; }
    //    public int ItemQuantity { get; set; }
    //    public decimal PriceForBox
    //        => ItemQuantity * Item.Price;

    //    public override string ToString()
    //    {
    //        StringBuilder sb = new StringBuilder();
    //        sb.AppendLine(SerialNumber);
    //        sb.AppendLine($"-- {Item.Name} - ${Item.Price:F2}: {ItemQuantity}");
    //        sb.AppendLine($"-- ${PriceForBox:F2}");

    //        return sb.ToString();
    //    }
    //}

}
