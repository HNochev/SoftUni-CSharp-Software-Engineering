using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1; i <= number; i++)
            {
                if (DividableByEight(i) && OneOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }

        }

        static bool DividableByEight(int num)
        {
            int sumDigits = 0;
            while (num != 0)
            {
                sumDigits = sumDigits + (num % 10);
                num = num / 10;
            }
            if (sumDigits % 8 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool OneOddDigit(int num)
        {
            bool isOdd = false;
            int digit = 0;
            while (num != 0)
            {
                digit = num % 10;
                num = num / 10;
                if (digit % 2 != 0)
                {
                    isOdd = true;
                }
            }
            if (isOdd == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
