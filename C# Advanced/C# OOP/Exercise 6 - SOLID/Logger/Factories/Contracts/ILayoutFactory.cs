using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_6___SOLID.Factories.Contracts
{
    using Models.Contracts;

    public interface ILayoutFactory
    {
        ILayout GetLayout(string type);
    }
}