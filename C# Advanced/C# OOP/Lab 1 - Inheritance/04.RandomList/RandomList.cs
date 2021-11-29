using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList<T> : List<T>
    {
        private Random random;

        public RandomList()
        {
            this.random = new Random();
        }

        public T RandomString()
        {
            return this[random.Next(0, this.Count)];
        }
    }
}
