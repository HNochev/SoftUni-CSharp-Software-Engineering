using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private const int maxToppingCount = 10;

        private const int minNameLength = 1;
        private const int maxNameLength = 15;

        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (value.Length < minNameLength || value.Length > maxNameLength)
                {
                    throw new ArgumentException($"Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }

        public Dough Dough { get; set; }

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count == maxToppingCount)
            {
                throw new InvalidOperationException($"Number of toppings should be in range [0..{maxToppingCount}].");
            }

            this.toppings.Add(topping);
        }

        public double TotalCalories()
        {
            return this.Dough.DoughCalories() + this.toppings.Sum(x => x.ToppingCalories());
        }
    }
}
