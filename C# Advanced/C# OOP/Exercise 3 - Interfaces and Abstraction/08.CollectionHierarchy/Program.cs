using _08.CollectionHierarchy.Contracts;
using _08.CollectionHierarchy.Core;
using _08.CollectionHierarchy.Models;
using System;
using System.Collections.Generic;

namespace _08.CollectionHierarchy
{
    class Program
    {
        public static void Main(string[] args)
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            var engine = new Engine(
                addCollection,
                addRemoveCollection,
                myList);

            engine.Run();
        }
    }
}
