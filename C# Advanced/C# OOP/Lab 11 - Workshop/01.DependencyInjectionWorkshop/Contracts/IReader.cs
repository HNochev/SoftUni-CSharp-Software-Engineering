using _01.DependencyInjectionWorkshop.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01.DependencyInjectionWorkshop.Contracts
{
    interface IReader
    {
        Position ReadKey();

        string ReadLine();
    }
}
