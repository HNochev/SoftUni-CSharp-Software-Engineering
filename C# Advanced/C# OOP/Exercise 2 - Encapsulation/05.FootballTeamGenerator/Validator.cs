using System;
using System.Collections.Generic;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public static class Validator
    {
        public static void ThrowIfStringIsNullOrWhiteSpace(string str, string message)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentException(message);
            }
        }

        public static void ThrowIfNumberISNotInRange(double stat,int min, int max, string message)
        {
            if (stat < min || stat > max)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
