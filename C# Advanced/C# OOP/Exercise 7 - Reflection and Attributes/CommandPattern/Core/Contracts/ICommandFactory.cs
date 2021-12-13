using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Contracts
{
    interface ICommandFactory
    {
        ICommand CreateCommand(string commandType);
    }
}
