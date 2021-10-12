using System;
using System.Linq;

namespace _10.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));

            Console.WriteLine(GetMultiplyEvenANdOdds(number));

        }
        static int GetMultiplyEvenANdOdds(int num)
        {
            int result = SumOfEvenNums(num) * SumOfOddNums(num);
            return result;
        }
        static int SumOfEvenNums(int num)
        {
            int symbol = 0;
            int evenSum = 0;

            while(num != 0)
            {
                symbol = num % 10;
                if (symbol % 2 == 0)
                {
                    evenSum = evenSum + symbol;
                }
                num = num / 10;
            }
            return evenSum;
        }
        static int SumOfOddNums(int num)
        {
            int symbol = 0;
            int oddSum = 0;

            while (num != 0)
            {
                symbol = num % 10;
                if (symbol % 2 != 0)
                {
                    oddSum = oddSum + symbol;
                }
                num = num / 10;
            }
            return oddSum;
        }
    }
}
