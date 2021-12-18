using _02.MicrosoftDepencyInjection.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _02.MicrosoftDepencyInjection.Loggers
{
    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
