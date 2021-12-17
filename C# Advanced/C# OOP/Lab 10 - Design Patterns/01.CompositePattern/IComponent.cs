using System;
using System.Collections.Generic;
using System.Text;

namespace _01.CompositePattern
{
    interface IComponent
    {
        void Add(IComponent component);

        void Remove(IComponent component);

        void Draw();

        void Move(Position position);
    }
}
