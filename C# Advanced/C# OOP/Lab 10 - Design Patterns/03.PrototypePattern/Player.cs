using System;
using System.Collections.Generic;
using System.Text;

namespace _03.PrototypePattern
{
    class Player : ICloneable
    {
        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
