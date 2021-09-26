using System;

namespace _06._SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int number = 1111; number <= 9999; number++)
            {
                int tousands = number / 1000;
                int hundreds = (number / 100) % 10;
                int tens = (number / 10) % 10;
                int units = number % 10;

                bool special = tousands != 0 && hundreds != 0 && tens != 0 && units != 0 && n % tousands == 0 && n % hundreds == 0 && n % tens == 0 && n % units == 0;

                if (special)
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}
