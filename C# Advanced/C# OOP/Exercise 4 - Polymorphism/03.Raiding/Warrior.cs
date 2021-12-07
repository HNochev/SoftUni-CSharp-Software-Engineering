using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Warrior : BaseHero
    {
        private const int Power = 100;
        public Warrior(string name) : base(name, Power)
        {
        }

        public override string CastAbility()
        {
            return base.CastAbility() + $" hit for {Power} damage";
        }
    }
}
