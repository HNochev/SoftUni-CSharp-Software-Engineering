using Microsoft.Extensions.DependencyInjection;
using System;

namespace _02.MicrosoftDepencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = ServiceConfigurator.ConfigureServices();

            Engine engine = serviceProvider.GetRequiredService<Engine>();

            engine.Start();
            engine.End();
        }
    }
}
