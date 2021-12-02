using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.bagOfProducts = new List<Product>();
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

        public decimal Money
        {
            get => this.money;
            private set
            {
                Validator.ThrowIfMoneyAreNegative(value, "Money cannot be negative");

                this.money = value;
            }
        }

        public void AddProduct(Product product)
        {
            if (product.Cost <= this.Money)
            {
                bagOfProducts.Add(product);
                this.Money = this.Money - product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            if (bagOfProducts.Count > 0)
            {
                return $"{this.Name} - {string.Join(", ", bagOfProducts.Select(n => n.Name))}";
            }
            else
            {
                return $"{this.Name} - Nothing bought";
            };
        }
    }
}
