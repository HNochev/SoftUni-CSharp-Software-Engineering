using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double BaseWeightModifier = 0.30;
        private static HashSet<string> CatAllowedFoods = new HashSet<string>
        {
            nameof(Vegetable),
            nameof(Meat)
        };

        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, CatAllowedFoods, BaseWeightModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
