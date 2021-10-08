using System;

namespace _05._SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                int sumOfDigits = 0;
                int oneDigit = i;
                while (oneDigit > 0)
                {
                    sumOfDigits = sumOfDigits + (oneDigit % 10);
                    oneDigit = oneDigit / 10;
                }
                bool isSpecial = (sumOfDigits == 5) || (sumOfDigits == 7) || (sumOfDigits == 11);
                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}
