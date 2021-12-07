using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        private const double BaseWeightModifier = 0.35;
        private static HashSet<string> HenAllowedFoods = new HashSet<string>
        {
            nameof(Meat),
            nameof(Vegetable),
            nameof(Fruit),
            nameof(Seeds)
        };

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, HenAllowedFoods, BaseWeightModifier, wingSize)
        {
        }

        public override string ProduceSound()
        {
            return $"Cluck";
        }
    }
}
