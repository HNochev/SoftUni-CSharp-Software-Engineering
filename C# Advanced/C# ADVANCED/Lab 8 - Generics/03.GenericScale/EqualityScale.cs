﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        private T right;
        private T left;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            return left.Equals(right);
        }
    }
}
