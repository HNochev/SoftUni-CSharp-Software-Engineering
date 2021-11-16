using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Tire
    {
        public Tire(int[] years, double[] pressures)
        {
            this.Years = years;
            this.Pressures = pressures;
        }

        public int[] Years { get; set; }

        public double[] Pressures { get; set; }
    }
}
