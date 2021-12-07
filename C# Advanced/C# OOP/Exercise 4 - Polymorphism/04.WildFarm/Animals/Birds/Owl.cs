using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        private const double BaseWeightModifier = 0.25;
        private static HashSet<string> OwlAllowedFood = new HashSet<string>
        {
            nameof(Meat)
        };

        public Owl(string name, double weight, double wingSize)
            : base(name, weight, OwlAllowedFood, BaseWeightModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return $"Hoot Hoot";
        }
    }
}
