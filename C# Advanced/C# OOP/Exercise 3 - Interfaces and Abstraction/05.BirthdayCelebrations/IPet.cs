using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
    public interface IPet : IBirthable
    {
        public string Name { get; }
    }
}
