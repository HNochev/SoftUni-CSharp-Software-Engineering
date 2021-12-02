using System;
using System.Collections.Generic;
using System.Text;

namespace _03.ShoppingSpree
{
    public static class Validator
    {
        public static void ThrowIfStringIsNullOrEmpty(string str, string message)
        {
            if(string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfMoneyAreNegative(decimal money, string message)
        {
            if(money < 0)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
