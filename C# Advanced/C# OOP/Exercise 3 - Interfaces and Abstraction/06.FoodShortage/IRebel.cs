using System;
using System.Collections.Generic;
using System.Text;

namespace _06.FoodShortage
{
    public interface IRebel : IBuyer
    {
        public string Name { get; }

        public int Age { get; }

        public string Group { get; }
    }
}
