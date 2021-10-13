using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            FactorielSum(first, second);
        }
        static void FactorielSum(int a, int b)
        {
            double firstFactorialSum = 1;
            double secondFactorialSum = 1;
            for (int i = a ; i >= 1; i--)
            {
                firstFactorialSum = firstFactorialSum * i;
            }
            for (int i = b ; i >= 1; i--)
            {
                secondFactorialSum = secondFactorialSum * i;
            }
            Console.WriteLine($"{firstFactorialSum/ secondFactorialSum:f2}");
        }
    }
}
