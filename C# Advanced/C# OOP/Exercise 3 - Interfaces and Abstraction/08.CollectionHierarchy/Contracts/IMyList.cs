using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Contracts
{
    public interface IMyList : IAddRemoveCollection
    {
        int Used { get; }
    }
}
