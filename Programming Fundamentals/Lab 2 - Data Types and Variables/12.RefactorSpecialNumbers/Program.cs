using System;

namespace _12.RefactorSpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumOfDigit = 0;
            int digit = 0;

            for (int i = 1; i <= n; i++)
            {
                digit = i;
                while (digit > 0)
                {
                    sumOfDigit += digit % 10;
                    digit = digit / 10;
                }
                bool isSpecial = (sumOfDigit == 5) || (sumOfDigit == 7) || (sumOfDigit == 11);
                Console.WriteLine($"{i} -> {isSpecial}");
                sumOfDigit = 0;
            }

        }
    }
}
