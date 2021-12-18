using _01.DependencyInjectionWorkshop.Common;
using _01.DependencyInjectionWorkshop.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.DependencyInjectionWorkshop.Movers
{
    class FastMover : IMover
    {
        public void Move(IGameObject gameObject, Position position)
        {
            gameObject.Position.X += position.X * 10;
            gameObject.Position.Y += position.Y * 10;
        }
    }
}
