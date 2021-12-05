using _08.CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Models
{
    public class MyList : AddRemoveCollection, IMyList
    {
        public int Used => this.Data.Count;

        public override string Remove()
        {
            string item = this.Data[0];
            this.Data.RemoveAt(0);

            return item;
        }
    }
}
