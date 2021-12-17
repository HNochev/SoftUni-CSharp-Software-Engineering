﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _01.CommandPattern.Commands
{
    class MultiplyCommand : Command
    {
        public MultiplyCommand(decimal valueToChange) : base(valueToChange)
        { }

        public override decimal Execute(decimal value)
        {
            return value * ValueToChange;
        }

        public override decimal Unexecute(decimal value)
        {
            return value / ValueToChange;
        }
    }
}
