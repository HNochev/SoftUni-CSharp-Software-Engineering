using System;
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodString
{
    public class Box<T>
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
