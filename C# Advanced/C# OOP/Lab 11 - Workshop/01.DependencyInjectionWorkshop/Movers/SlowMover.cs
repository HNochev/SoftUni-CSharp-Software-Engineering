using _01.DependencyInjectionWorkshop.Common;
using _01.DependencyInjectionWorkshop.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.DependencyInjectionWorkshop.Movers
{
    class SlowMover : IMover
    {
        public void Move(IGameObject gameObject, Position position)
        {
            gameObject.Position.X += position.X;
            gameObject.Position.Y += position.Y;
        }
    }
}
