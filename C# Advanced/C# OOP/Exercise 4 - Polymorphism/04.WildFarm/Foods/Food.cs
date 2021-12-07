using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Foods
{
    public abstract class Food
    {
        public Food(int quantity)
        {
            this.Quantity = quantity;
        }
        public int Quantity { get; private set; }
    }
}
