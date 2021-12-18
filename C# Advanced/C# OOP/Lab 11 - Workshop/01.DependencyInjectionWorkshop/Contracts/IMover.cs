using _01.DependencyInjectionWorkshop.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.DependencyInjectionWorkshop.Contracts
{
    interface IMover
    {
        void Move(IGameObject gameObject, Position position);
    }
}
