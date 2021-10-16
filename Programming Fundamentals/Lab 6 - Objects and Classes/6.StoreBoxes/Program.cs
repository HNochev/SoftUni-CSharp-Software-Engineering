using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Box> boxes = new List<Box>();

            while (input != "end")
            {
                string[] text = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string serialNumber = text[0];
                string itemName = text[1];
                int quantity = int.Parse(text[2]);
                double price = double.Parse(text[3]);

                double boxPrice = quantity * price;

                Item item = new Item(itemName, price);
                Box box = new Box(serialNumber, item, quantity, boxPrice);

                boxes.Add(box);
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, boxes.OrderByDescending(x => x.BoxPrice)));
        }
    }
}
