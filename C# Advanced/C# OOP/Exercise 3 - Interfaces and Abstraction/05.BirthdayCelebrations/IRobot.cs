using System;
using System.Collections.Generic;
using System.Text;

namespace _05.BirthdayCelebrations
{
    public interface IRobot : IIdentifiable
    {
        public string Model { get; }
    }
}
