using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Commands
{
    public class GoodEveningCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Good Evening Mr. {args[0]}";
        }
    }
}
