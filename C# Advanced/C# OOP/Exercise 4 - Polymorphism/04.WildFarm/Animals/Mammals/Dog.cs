using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        private const double BaseWeightModifier = 0.40;
        private static HashSet<string> DogAllowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };

        public Dog(string name, double weight, string livingRegion) : base(name, weight, DogAllowedFoods, BaseWeightModifier, livingRegion)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
