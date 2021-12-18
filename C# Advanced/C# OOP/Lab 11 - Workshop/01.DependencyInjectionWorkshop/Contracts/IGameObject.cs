using _01.DependencyInjectionWorkshop.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.DependencyInjectionWorkshop.Contracts
{
    interface IGameObject : IDrawable
    {
        Position Position { get; }
    }
}
