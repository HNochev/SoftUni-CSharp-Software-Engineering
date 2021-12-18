using _01.DependencyInjectionWorkshop.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.DependencyInjectionWorkshop.Contracts
{
    interface IDrawer
    {
        void DrawAtPosition(Position position, string toDraw);
    }
}
