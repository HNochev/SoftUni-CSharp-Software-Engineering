using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
    public interface ICitizen : IIdentifiable, IBirthable
    {
        public string Name { get; }

        public int Age { get; }
    }
}
