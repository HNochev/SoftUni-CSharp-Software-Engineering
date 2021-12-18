using System;
using System.Collections.Generic;
using System.Text;

namespace _01.DependencyInjectionWorkshop.DI.Attributes
{
    [AttributeUsage(AttributeTargets.Constructor)]
    class Inject : Attribute
    {
    }
}
