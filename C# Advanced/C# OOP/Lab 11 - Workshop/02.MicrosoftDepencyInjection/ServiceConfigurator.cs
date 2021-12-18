using Microsoft.Extensions.DependencyInjection;
using _02.MicrosoftDepencyInjection.Contracts;
using _02.MicrosoftDepencyInjection.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02.MicrosoftDepencyInjection
{
    class ServiceConfigurator
    {
        public static ServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<ILogger, FileLogger>(f => new FileLogger("../../../logstest.txt"));

            //serviceCollection.AddTransient<ILogger, ConsoleLogger>();

            serviceCollection.AddTransient<Engine, Engine>();

            serviceCollection.AddTransient<IGameMovement, GameMovement>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}
