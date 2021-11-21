using System;
using System.Collections.Generic;
using System.Text;

namespace _06.GenericCountMethodDouble
{
    public class Box<T>
        where T : IComparable
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public override string ToString()
        {
            Type type = this.Value.GetType();
            string fullnameType = type.FullName;

            return $"{fullnameType}: {this.Value}";
        }
    }
}
