using System;
using System.Collections.Generic;
using System.Text;

namespace _6.StoreBoxes
{
    public class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int QuantityItem { get; set; }
        public double BoxPrice { get; set; }

        public Box(string serialNumber, Item item, int quantity, double boxPrice)
        {
            this.SerialNumber = serialNumber;
            this.Item = item;
            this.QuantityItem = quantity;
            this.BoxPrice = boxPrice;
        }
        public Box()
        {
            Item = new Item();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(SerialNumber);
            sb.AppendLine($"-- {Item.Name} - ${Item.Price:f2}: {QuantityItem}");
            sb.AppendLine($"-- ${BoxPrice:f2}");

            return sb.ToString().TrimEnd();
        }
    }
}
