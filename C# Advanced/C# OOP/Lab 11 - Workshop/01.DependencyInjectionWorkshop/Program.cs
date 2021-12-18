using Autofac;
using _01.DependencyInjectionWorkshop.Contracts;
using _01.DependencyInjectionWorkshop.DI;
using _01.DependencyInjectionWorkshop.DI.Containers;
using _01.DependencyInjectionWorkshop.Loggers;
using System;

namespace _01.DependencyInjectionWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = InjectorSingleton.Instance.Resolve<Engine>();

            engine.Start();
            engine.End();
        }
    }
}
