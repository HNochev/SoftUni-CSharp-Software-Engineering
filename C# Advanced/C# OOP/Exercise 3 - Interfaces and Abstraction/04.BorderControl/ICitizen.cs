using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public interface ICitizen : IIdentifiable
    {
        public string Name { get; }

        public int Age { get; }
    }
}
