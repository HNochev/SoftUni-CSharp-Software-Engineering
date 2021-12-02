using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Cost = price;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ThrowIfStringIsNullOrEmpty(value, "Name cannot be empty");

                this.name = value;
            }
        }

        public decimal Cost
        {
            get => this.cost;
            private set
            {
                Validator.ThrowIfMoneyAreNegative(value, "Money cannot be negative");

                this.cost = value;
            }
        }
    }
}
