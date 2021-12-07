using _04.WildFarm.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double BaseWeightModifier = 1.00;
        private static HashSet<string> TigerAllowedFoods = new HashSet<string>
        {
            nameof(Meat)
        };

        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, TigerAllowedFoods, BaseWeightModifier, livingRegion, breed)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
