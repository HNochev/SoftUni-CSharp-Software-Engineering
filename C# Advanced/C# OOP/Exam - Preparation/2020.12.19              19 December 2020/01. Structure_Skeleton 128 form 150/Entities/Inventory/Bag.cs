using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private List<Item> items;

        public Bag(int capacity)
        {
            this.Capacity = 100;
            this.items = new List<Item>();
        }

        public int Capacity { get; set; }

        public int Load
        {
            get => items.Sum(x => x.Weight);
        }

        public IReadOnlyCollection<Item> Items => this.items;

        public void AddItem(Item item)
        {
            if(this.Capacity < this.Load + item.Weight)
            {
                throw new InvalidOperationException("Bag is full!");
            }
            items.Add(item);
        }

        public Item GetItem(string name)
        {
            if(items.Count == 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }
            if (!items.Any(x => x.GetType().Name == name))
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }
            Item item = items.First(x => x.GetType().Name == name);
            items.Remove(item);
            return item;
        }
    }
}
