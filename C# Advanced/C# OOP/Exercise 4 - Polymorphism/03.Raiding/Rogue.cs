using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Rogue : BaseHero
    {
        private const int Power = 80;
        public Rogue(string name) : base(name, Power)
        {
        }

        public override string CastAbility()
        {
            return base.CastAbility() + $" hit for {Power} damage";
        }
    }
}
