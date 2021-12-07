using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Paladin : BaseHero
    {
        private const int Power = 100;
        public Paladin(string name) : base(name, Power)
        {
        }

        public override string CastAbility()
        {
            return base.CastAbility() + $" healed for {Power}";
        }
    }
}
