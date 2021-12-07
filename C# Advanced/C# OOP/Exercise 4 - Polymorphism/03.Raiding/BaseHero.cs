using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }

        public string Name { get; private set; }

        public int Power { get; private set; }

        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name}";
        }
    }
}
