using _01.DependencyInjectionWorkshop.Contracts;
using _01.DependencyInjectionWorkshop.DI.Containers;
using _01.DependencyInjectionWorkshop.Drawers;
using _01.DependencyInjectionWorkshop.Loggers;
using _01.DependencyInjectionWorkshop.Movers;
using _01.DependencyInjectionWorkshop.Readers;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.DependencyInjectionWorkshop
{
    public class SnakeGameContainer : AbstractContainer
    {
        public override void ConfigureServices()
        {
            CreateMapping<ILogger, FileLogger>(() => new FileLogger("../../../logs.txt"));
            CreateMapping<IReader, ConsoleReader>();
            CreateMapping<IDrawer, ConsoleDrawer>();
            CreateMapping<IMover, FastMover>();
        }
    }
}
