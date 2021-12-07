using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Druid : BaseHero
    {
        private const int Power = 80;
        public Druid(string name) : base(name, Power)
        {
        }

        public override string CastAbility()
        {
            return base.CastAbility() + $" healed for {Power}";
        }
    }
}
