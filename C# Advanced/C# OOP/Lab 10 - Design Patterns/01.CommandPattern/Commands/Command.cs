using System;
using System.Collections.Generic;
using System.Text;

namespace _01.CommandPattern.Commands
{
    abstract class Command : ICommand
    {
        public Command(decimal value)
        {
            ValueToChange = value;
        }

        public decimal ValueToChange { get; set; }

        public abstract decimal Execute(decimal value);

        public abstract decimal Unexecute(decimal value);
    }
}
