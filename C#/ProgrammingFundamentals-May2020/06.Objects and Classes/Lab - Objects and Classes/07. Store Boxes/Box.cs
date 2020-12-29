using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Store_Boxes
{
    class Box
    {
        public Box(string serial, Item item, int quantity)
        {
            SerialNumber = serial;
            ItemQuantity = quantity;
            Item = item;
        }
        public Item Item { get; set; }
        public string SerialNumber { get; set; }
        public int ItemQuantity { get; set; }
        public decimal PriceForBox
            => ItemQuantity * Item.Price;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(SerialNumber);
            sb.AppendLine($"-- {Item.Name} - ${Item.Price:F2}: {ItemQuantity}");
            sb.AppendLine($"-- ${PriceForBox:F2}");

            return sb.ToString();
        }
    }
}
