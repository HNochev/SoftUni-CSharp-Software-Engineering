using System;
using System.Collections.Generic;
using System.Text;

namespace _09.ExplicitInterfaces.Contracts
{
    public interface IResident
    {
        public string Name { get; }

        public string Country { get; }

        string GetName();
    }
}
