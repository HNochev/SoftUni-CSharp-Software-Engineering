﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _04.BorderControl
{
    public interface IRobot : IIdentifiable
    {
        public string Model { get; }
    }
}
