using System;
using System.Collections.Generic;
using System.Text;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private string type;
        private int weight;

        private const int minWeight = 1;
        private const int maxWeight = 50;

        public Topping(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        public string Type
        {
            get => this.type;
            private set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        public int Weight
        {
            get => this.weight;
            private set
            {
                if (value < minWeight || value > maxWeight)
                {
                    throw new ArgumentException($"{this.Type} weight should be in the range [{minWeight}..{maxWeight}].");
                }
                this.weight = value;
            }
        }

        public double ToppingCalories()
        {
            double typeCalories = 0;
            if (this.Type.ToLower() == "meat")
            {
                typeCalories = 1.2;
            }
            else if (this.Type.ToLower() == "veggies")
            {
                typeCalories = 0.8;
            }
            else if (this.Type.ToLower() == "cheese")
            {
                typeCalories = 1.1;
            }
            else if (this.Type.ToLower() == "sauce")
            {
                typeCalories = 0.9;
            }

            return this.Weight * typeCalories * 2.0;
        }
    }
}
